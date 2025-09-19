using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClassicalMusicApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RaagaDetails",
                url: "raaga/{name}",
                defaults: new { controller = "Raaga", action = "Details" }
            );

            routes.MapRoute(
                name: "ThaatDetails",
                url: "thaat/{name}",
                defaults: new { controller = "Thaat", action = "Details" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
