using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class SuburbsController : Controller
    {
        Dictionary<int, List<Suburb>> dictionary = new Dictionary<int, List<Suburb>>
        {
            {
                1,
                new List<Suburb>
                {
                    new Suburb { id = 1, name = "Evanston", city_id = 1 },
                    new Suburb { id = 2, name = "Arlington Heights", city_id = 1 }
                }
            },
            {
                2,
                new List<Suburb>
                {
                    new Suburb { id = 3, name = "West Nyack", city_id = 2 },
                    new Suburb { id = 4, name = "Long Island", city_id = 2 }
                }
            },
            {
                3,
                new List<Suburb>
                {
                    new Suburb { id = 5, name = "York", city_id = 3 },
                    new Suburb { id = 6, name = "West York", city_id = 3 }
                }
            },
            {
                4,
                new List<Suburb>
                {
                    new Suburb { id = 7, name = "Longueuil", city_id = 4 },
                    new Suburb { id = 8, name = "Brossard", city_id = 4 }
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
            Suburb suburb = null;

            // kind of ugly but normally this would be a database fetch
            foreach (KeyValuePair<int, List<Suburb>> kv in dictionary)
            {
                foreach (Suburb s in kv.Value)
                {
                    if (s.id == id)
                    {
                        suburb = s;
                        break;
                    }
                }
                if (suburb != null)
                    break;
            }

            return Json(suburb, JsonRequestBehavior.AllowGet);
        }
    }
}
