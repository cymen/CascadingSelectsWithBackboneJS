using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CitiesController : Controller
    {
        Dictionary<int, List<City>> dictionary = new Dictionary<int, List<City>>
        {
            {
                1,
                new List<City>
                {
                    new City { id = 1, name = "Chicago", country_id = 1 },
                    new City { id = 2, name = "New York", country_id = 1 }
                }
            },
            {
                2,
                new List<City>
                {
                    new City { id = 3, name = "Toronto", country_id = 2 },
                    new City { id = 4, name = "Montreal", country_id = 2 }
                }
            }
        };

        public JsonResult Index(int id)
        {
            return Json
                (
                    (dictionary.ContainsKey(id) ? dictionary[id] : null),
                    JsonRequestBehavior.AllowGet    // normally not set (google to see security issues) but for demo project allowing GET
                );
        }

        public JsonResult Detail(int id)
        {
            City city = null;
            foreach (KeyValuePair<int, List<City>> kv in dictionary)
            {
                foreach (City c in kv.Value)
                {
                    if (c.id == id)
                    {
                        city = c;
                        break;
                    }
                }
                if (city != null)
                    break;
            }

            return Json(city, JsonRequestBehavior.AllowGet);
        }
    }
}
