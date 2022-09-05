using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcECommerceWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "aboutroute",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
                );

            routes.MapRoute(
                name: "contactroute",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact" }
                );
            routes.MapRoute(
               name: "productroute",
               url: "Products",
               defaults: new { controller = "ViewProduct", action = "Contact" }
               );
            routes.MapRoute(
               name: "adminproductroute",
               url: "Product",
               defaults: new { controller = "Products", action = "Index" }
               );
          



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
