using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_NMM.Basic.DAL
{
    public class BreweryRepository : IBreweryRepository
    {
        private List<Brewery> breweries = null;

        /// <summary>
        /// Constructor - default
        /// </summary>
        public BreweryRepository()
        {
            //
            // Note: the brewers list directly references the session variable list.
            // All changes to the breweries list will be immediately implement in the session variable list.
            // Calling the Save() method in this case will be unnecessary.
            //
            this.breweries = (List<Brewery>)HttpContext.Current.Session["Breweries"];
        }

        /// <summary>
        /// Constructor - overloaded to accept a list of breweries
        /// </summary>
        /// <param name="breweries">List<Brewery> breweries</param>
        public BreweryRepository(List<Brewery> breweries)
        {
            this.breweries = breweries;
        }

        /// <summary>
        /// Return all breweries as and enumerable
        /// </summary>
        /// <returns>enumerable all breweries</returns>
        public IEnumerable<Brewery> SelectAll()
        {
            return this.breweries;
        }

        /// <summary>
        /// Return a brewery
        /// </summary>
        /// <param name="id">int brewery ID</param>
        /// <returns></returns>
        public Brewery SelectByID(int id)
        {
            var index = breweries.FindIndex(a => a.ID == id);

            if (index != -1) return this.breweries[index];
            else throw new ArgumentException("BreweryNotFound");
        }

        /// <summary>
        /// Add a new brewery
        /// </summary>
        /// <param name="brewery">object Brewery</param>
        public void Insert(Brewery brewery)
        {
            this.breweries.Add(brewery);
        }

        /// <summary>
        /// Update a brewery
        /// </summary>
        /// <param name="brewery">int ID of brewery</param>
        public void Update(Brewery brewery)
        {
            var index = this.breweries.FindIndex(a => a.ID == brewery.ID);

            if (index != -1) this.breweries[index] = brewery;
            else throw new ArgumentException("BreweryNotFound");
        }

        /// <summary>
        /// Delete a brewery
        /// </summary>
        /// <param name="id">int ID of brewery</param>
        public void Delete(int id)
        {
            var index = this.breweries.FindIndex(a => a.ID == id);

            if (index != -1) this.breweries.RemoveAt(index);
            else throw new ArgumentException("BreweryNotFound");
        }

        /// <summary>
        /// Save is unnecessary given each method manipulates the session variable directly.
        /// If a form of persistence is used the data source would be updated at this point.
        /// </summary>
        public void Save()
        {
            // Implement a save to the persistent data source
        }

        /// <summary>
        /// Find the largest ID number, increment it, and return the value
        /// </summary>
        /// <returns>int next ID value</returns>
        public int GetNextID()
        {
            return this.breweries.Max(x => x.ID) + 1;
        }

        /// <summary>
        /// Dispose method required on all classes implementing the IDisposable interface
        /// </summary>
        public void Dispose()
        {
            //
            // Allow the Garbage Collector to handle disposing the list of brewery objects
            //
        }
    }
}