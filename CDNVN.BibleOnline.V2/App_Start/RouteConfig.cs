using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CDNVN.BibleOnline.V2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1:1-2:1
            routes.MapRoute(
                name: "Read1",
                url: "doc-kinh-thanh/{book}_{fromChapter}.{fromVerse}-{toChapter}.{toVerse}",
                defaults: new { controller = "Read", action = "Index", book = UrlParameter.Optional, fromChapter = UrlParameter.Optional, fromVerse = UrlParameter.Optional, toChapter = UrlParameter.Optional, toVerse = UrlParameter.Optional }
            );
            //1:1-2
            routes.MapRoute(
                name: "Read2",
                url: "doc-kinh-thanh/{book}_{fromChapter}.{fromVerse}-{toVerse}",
                defaults: new { controller = "Read", action = "Index" }
            );
            //1-2:1
            routes.MapRoute(
                name: "Read3",
                url: "doc-kinh-thanh/{book}_{fromChapter}-{toChapter}.{toVerse}",
                defaults: new { controller = "Read", action = "Index" }
            );
            //1-2
            routes.MapRoute(
               name: "Read4",
               url: "doc-kinh-thanh/{book}_{fromChapter}-{toChapter}",
               defaults: new { controller = "Read", action = "Index" }
           );
            
            //1:1
            routes.MapRoute(
                name: "Read5",
                url: "doc-kinh-thanh/{book}_{fromChapter}.{fromVerse}",
                defaults: new { controller = "Read", action = "Index"}
            );
            //1
            routes.MapRoute(
                name: "Read6",
                url: "doc-kinh-thanh/{book}_{fromChapter}",
                defaults: new { controller = "Read", action = "Index"}
            );

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
