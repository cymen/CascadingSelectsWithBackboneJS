using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Suburb
    {
        public int id { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
    }
}