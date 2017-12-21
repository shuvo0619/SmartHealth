using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartHealth
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "Message",
            "SendMessage/{UserId}",
            new { controller = "Message", action = "SendMessage" });

                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SmartHealth.Controllers" }
            );

               // routes.MapRoute(
               //"Patient",
               //"PatientProfile/{UserId}",
               //new { controller = "Patient", action = "PatientProfile" });

               // routes.MapRoute(
               //"Message",
               //"SendMessage/{UserId}",
               //new { controller = "Message", action = "SendMessage" });

               // routes.MapRoute(
               // "Doctor",
               // "{Doctor}/{Index}/{UserId}",
               // new { controller = "Doctor", action = "Index" });

               // routes.MapRoute(
               // "ViewProfile",
               // "ViewProfile/{DoctorId}",
               // new { controller = "Doctor", action = "ViewProfile"});
        }
    }
}
