using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CountriesController : Controller
    {
        public JsonResult Index()
        {
            List<Country> countries = new List<Country>
            {
                new Country { id = 1, name = "USA" },
                new Country { id = 2, name = "Canada" }
            };

            return Json
                (
                    countries,
                    JsonRequestBehavior.AllowGet    // normally not set (google to see security issues) but for demo project allowing GET
                );
        }
    }
}
