using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;


namespace Gemma
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomePage",
                url: "DaniellaGemma",
                defaults: new
                {
                    Controller = "Home",
                    action = "DaniellaGemma",
                }
                );

            routes.MapRoute(
                name: "MemberCenter",
                url: "MemberCenter/{action}/{id}",
                defaults: new { controller = "MemberCenter", action = "MemberInfo", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "FindCategory",
                url: "DaniellaGemma/OnlineStore/{category}",
                defaults: new
                {
                    controller = "OnlineStore",
                    action = "FindBrand",
                    category = UrlParameter.Optional
                }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DaniellaGemma", id = UrlParameter.Optional }
            );
        }
    }
}
