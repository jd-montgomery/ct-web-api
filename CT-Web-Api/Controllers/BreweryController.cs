using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CT_Web_Api.Controllers
{
    public class BreweryController : Controller
    {
        // GET: Brewery
        public ActionResult Index()
        {
			var service = new DataAccessLayer.Services.Brewery(new ApplicationDbContext());
			var breweries = service.GetAllBreweries();

            return View(breweries);
        }
    }
}