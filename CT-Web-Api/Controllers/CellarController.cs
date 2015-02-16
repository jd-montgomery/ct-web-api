using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CT_Web_Api.Controllers
{
    public class CellarController : Controller
    {
        // GET: Cellar
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AddBeer()
		{
			return View();
		}
    }
}