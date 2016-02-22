using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Demo_NMM.Basic.Models;
using System.IO;

namespace Demo_NMM.Basic.DAL
{
    public class XMLBreweryRepository : IBreweryRepository
    {
        private List<Brewery> _breweries = null;
        private XmlReader xmlr;
        private XmlWriter xmlw;
        private string path = HttpRuntime.AppDomainAppPath + @"\Data\Breweries.xml";
        XmlReaderSettings xmlSettingsR = new XmlReaderSettings();
        XmlWriterSettings xmlSettingsW = new XmlWriterSettings();

        public XMLBreweryRepository()
        {
            xmlSettingsR.IgnoreComments = true;
            xmlSettingsR.IgnoreWhitespace = true;
            xmlSettingsW = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            BuildList();
        }

        private void BuildList()
        {
            _breweries = new List<Brewery>();
            using (xmlr = XmlReader.Create(path, xmlSettingsR))
            {
                xmlr.ReadToDescendant("Brewery");

                do
                {
                    Brewery b = new Brewery();
                    b.ID = int.Parse(xmlr.GetAttribute("id"));
                    xmlr.ReadStartElement("Brewery");
                    b.Name = xmlr.ReadElementContentAsString();
                    b.Address = xmlr.ReadElementContentAsString();
                    b.City = xmlr.ReadElementContentAsString();
                    b.State = (AppEnum.StateAbrv)Enum.Parse(typeof(AppEnum.StateAbrv), xmlr.ReadElementContentAsString());
                    b.Zip = xmlr.ReadElementContentAsString();
                    b.Phone = xmlr.ReadElementContentAsString();
                    _breweries.Add(b);
                }
                while (xmlr.ReadToNextSibling("Brewery"));
            }
        }

        public void Delete(int id)
        {
            BuildList();

            try
            {
                int selectedBreweryIndex = _breweries.FindIndex(x => x.ID == id);
                _breweries.RemoveAt(selectedBreweryIndex);
            }
            catch (IndexOutOfRangeException)
            {
                new ArgumentException("BreweryNotFound");
            }
            Save();
        }

        public void Dispose()
        {

        }

        public void Edit(Brewery brewery)
        {
            BuildList();

            try
            {
                int selectedBreweryIndex = _breweries.FindIndex(x => x.ID == brewery.ID);
                _breweries[selectedBreweryIndex] = brewery;
            }
            catch (IndexOutOfRangeException)
            {
                new ArgumentException("BreweryNotFound");
            }
            Save();
        }

        public int GetNextID()
        {
            BuildList();
            return _breweries.Max(x => x.ID) + 1;
        }

        public void Insert(Brewery brewery)
        {
            BuildList();

            brewery.ID = GetNextID();
            _breweries.Add(brewery);
            Save();
        }

        public void Save()
        {
            using (xmlw = XmlWriter.Create(path, xmlSettingsW))
            {
                xmlw.WriteStartDocument();
                xmlw.WriteStartElement("Breweries");

                foreach (Brewery b in _breweries)
                {
                    xmlw.WriteStartElement("Brewery");
                    xmlw.WriteAttributeString("id", b.ID.ToString());

                    xmlw.WriteStartElement("Name");
                    xmlw.WriteString(b.Name);
                    xmlw.WriteEndElement();

                    xmlw.WriteStartElement("Address");
                    xmlw.WriteString(b.Address);
                    xmlw.WriteEndElement();

                    xmlw.WriteStartElement("City");
                    xmlw.WriteString(b.City);
                    xmlw.WriteEndElement();

                    xmlw.WriteStartElement("State");
                    xmlw.WriteString(b.State.ToString());
                    xmlw.WriteEndElement();

                    xmlw.WriteStartElement("Zip");
                    xmlw.WriteString(b.Zip);
                    xmlw.WriteEndElement();

                    xmlw.WriteStartElement("Phone");
                    xmlw.WriteString(b.Phone);
                    xmlw.WriteEndElement();

                    xmlw.WriteEndElement();
                }

                xmlw.WriteEndDocument();
            }

            BuildList();
        }

        public IEnumerable<Brewery> SelectAll()
        {
            BuildList();
            return _breweries;
        }

        public Brewery SelectByID(int id)
        {
            BuildList();
            return this._breweries.Find(x => x.ID == id);
        }
    }
}