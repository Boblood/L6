using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Demo_NMM.Basic.DAL
{
    public class SessionBreweryRepository : IBreweryRepository
    {
        private List<Brewery> _breweries = null;

        #region Constructors

        public SessionBreweryRepository()
        {
            this._breweries = (List<Brewery>)HttpContext.Current.Session["Breweries"];
        }

        public SessionBreweryRepository(List<Brewery> breweries)
        {
            this._breweries = breweries;
        } 

        #endregion

        public void Delete(int id)
        {
            try
            {
                int selectedBreweryIndex = _breweries.FindIndex(x => x.ID == id);
                _breweries.RemoveAt(selectedBreweryIndex);
            }
            catch (IndexOutOfRangeException)
            {
                new ArgumentException("BreweryNotFound");
            }
        }

        public void Dispose()
        {
            
        }

        public void Edit(Brewery brewery)
        {
            try
            {
                int selectedBreweryIndex = _breweries.FindIndex(x => x.ID == brewery.ID);
                _breweries[selectedBreweryIndex] = brewery;
            }
            catch (IndexOutOfRangeException)
            {
                new ArgumentException("BreweryNotFound");
            }
        }

        public int GetNextID()
        {
             return _breweries.Max(x => x.ID) + 1;
        }

        public void Insert(Brewery brewery)
        {
            brewery.ID = GetNextID();
            _breweries.Add(brewery);
        }

        public void Save()
        {
            //not persistant data doesn't need to be saved
        }

        public IEnumerable<Brewery> SelectAll()
        {
            return this._breweries;
        }

        public Brewery SelectByID(int id)
        {
            return this._breweries.Find(x => x.ID == id);
        }
    }
}
