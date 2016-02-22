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
        // 
        // Landing page
        //
        public ActionResult Index()
        {
            return View();
        }

        //
        // Show table view
        //
        public ActionResult ShowTable()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return View(breweries);
        }

        //
        // Show list view
        //
        public ActionResult ShowList()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return View(breweries);
        }

        //
        // Show detail view
        //
        public ActionResult ShowDetail(int id)
        {
            return View();
        }

        //
        // Show brewery to delete in detail view
        // 
        public ActionResult DeleteBrewery(int id)
        {
            return View();
        }

        //
        // Process request from delete brewery form
        //
        [HttpPost]
        public ActionResult DeleteBrewery(FormCollection form)
        {
            return View();
        }

        //
        // Show new brewery form
        //
        public ActionResult CreateBrewery()
        {
            return View();
        }

        //
        // Process request from new brewery form
        //
        [HttpPost]
        public ActionResult CreateBrewery(FormCollection form)
        {
            return View();
        }

        //
        // Show brewery to update in edit view
        //
        public ActionResult UpdateBrewery(int id)
        {
            return View();
        }

        //
        // Process request from update brewery form
        //
        [HttpPost]
        public ActionResult UpdateBrewery(FormCollection form)
        {
            return View();
        }

        //
        // Reload initial data set
        //
        public ActionResult ReloadData()
        {
            DAL.Data.InitializeBreweries();

            return Redirect("/Breweries/ShowTable");
        }

        //
        // Get next ID number ensure uniqueness
        //
        private int GetNextID()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return breweries.Max(x => x.ID) + 1;
        }
    }
}