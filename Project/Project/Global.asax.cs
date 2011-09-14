using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute
            (
                "Suburbs",
                "cities/{id}/suburbs",
                new
                {
                    controller = "Suburbs",
                    action = "Index",
                }
            );

            routes.MapRoute
            (
                "Cities",
                "countries/{id}/cities",
                new
                {
                    controller = "Cities",
                    action = "Index",
                }
            );

            routes.MapRoute
            (
                "Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index"
                }
            );

            routes.MapRoute
            (
                "DefaultLazy",
                "{controller}/{id}",
                new
                {
                    action = "Detail"
                }
            );

            routes.MapRoute
            (
                "Home",
                "{controller}",
                new
                {
                    controller = "Home",
                    action = "Index"
                }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}