using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_NMM.Basic.Controllers
{
    public class BreweriesController : Controller
    {
        // GET: Breweries
        public ActionResult Index()
        {
            return View(InitialBreweries());
        }

        public ActionResult ShowTable()
        {
            return View(InitialBreweries());
        }

        public ActionResult ShowList()
        {
            return View(InitialBreweries());
        }

        private List<Brewery> InitialBreweries()
        {
            List<Brewery> breweries = new List<Brewery>();

            breweries.Add(new Brewery
            {
                Name = "Right Brain Brewery",
                Address = "225 E. 16th St",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "(231) 944-1239"
            });

            breweries.Add(new Brewery
            {
                Name = "Acoustic Tap Room",
                Address = "119 Maple St",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "(231) 883-2012"
            });

            breweries.Add(new Brewery
            {
                Name = "Beggars Brewery",
                Address = "4177 Village Park Dr. Suite C",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "N/A"
            });

            return breweries;
        }
    }
}