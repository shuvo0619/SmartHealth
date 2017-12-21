using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SmartHealth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string con = ConfigurationManager.ConnectionStrings["SmartHealth_Entities"].ConnectionString;
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            //here in Application Start we will start Sql Dependency
            SqlDependency.Start(con);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Session_Start(object sender, EventArgs e)
        //{
        //    NotificationComponent NC = new NotificationComponent();
        //    var currentTime = DateTime.Now;
        //    HttpContext.Current.Session["LastUpdated"] = currentTime;
        //    NC.RegisterNotification(currentTime);
        //}
        protected void Application_End()
        {
            //here we will stop Sql Dependency
            SqlDependency.Stop(con);
        }
    }
}
