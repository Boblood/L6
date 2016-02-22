using Demo_NMM.Basic.Models;
using Demo_NMM.Basic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_NMM.Basic.Controllers
{
    /// <summary>
    /// Breweries Controller
    /// </summary>
    public class BreweriesController : Controller
    {
        private IBreweryRepository br = null;

        public BreweriesController()
        {
            this.br = new BreweryRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            return View(br.SelectAll());
        }

        public ActionResult ShowList()
        {
            return View(br.SelectAll());
        }

        public ActionResult ShowDetail(int id)
        {
            return View(br.SelectByID(id));
        }


        public ActionResult DeleteBrewery(int id)
        {
            return View(br.SelectByID(id));
        }

        [HttpPost]
        public ActionResult DeleteBrewery(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                br.Delete(Convert.ToInt32(form["ID"]));
            }

            return Redirect("/Breweries/ShowTable");
        }

        public ActionResult CreateBrewery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrewery(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                Brewery newBrewery = new Brewery()
                {
                    ID = br.GetNextID(),
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = (AppEnum.StateAbrv)Enum.Parse(typeof(AppEnum.StateAbrv), form["state"]),
                    Zip = form["zip"],
                    Phone = form["phone"]
                };

                br.Insert(newBrewery);
            }

            return Redirect("/Breweries/ShowTable");
        }

        public ActionResult UpdateBrewery(int id)
        {
            return View(br.SelectByID(id));
        }

        [HttpPost]
        public ActionResult UpdateBrewery(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                Brewery updatedBrewery = new Brewery()
                {
                    ID = Convert.ToInt32(form["ID"]),
                    Name = form["Name"],
                    Address = form["Address"],
                    City = form["City"],
                    State = (AppEnum.StateAbrv)Enum.Parse(typeof(AppEnum.StateAbrv), form["State"]),
                    Zip = form["Zip"],
                    Phone = form["Phone"]
                };

                br.Update(updatedBrewery);
            }

            return Redirect("/Breweries/ShowTable");
        }

        /// <summary>
        /// Reload original data
        /// </summary>
        /// <returns>Redirect to table view</returns>
        public ActionResult ReloadData()
        {
            Demo_NMM.Basic.DAL.Data.InitializeBreweries();

            return Redirect("/Breweries/ShowTable");
        }
    }
}