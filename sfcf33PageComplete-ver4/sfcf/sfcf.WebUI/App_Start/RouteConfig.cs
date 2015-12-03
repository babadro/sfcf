using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sfcf.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new
                    {
                        controller = "Voting",
                        action = "List",
                        categoryId = (int?)null,
                        page = 1
                    }
                );

            routes.MapRoute(
                null,
                "Page{page}", 
                new { controller = "Voting", action = "List", categoryId = (int?)null },
                new { page = @"\d+" }
               );

            routes.MapRoute(
                null,
                "Category{categoryId}",
                new { controller = "Voting", action = "List", page = 1 },
                new {  page = @"\d+" }
                );

            routes.MapRoute(
                null,
                "Category{categoryId}/Page{page}",
                new { controller = "Voting", action = "List" },
                new {  page = @"\d+" }
                );

            
            routes.MapRoute(null, "{controller}/{action}");
            
        }
    }
}
