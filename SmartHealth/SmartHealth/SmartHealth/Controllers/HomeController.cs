using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHealth.Controllers
{
    public class HomeController : Controller
    {
        #region Global
   
        #endregion

        #region constructor
        //public HomeController(IRegistrationService registrationService,
        //    IUserTypeService userTypeService)
        //{
        //    this._RegistrationService = registrationService;
        //    this._UserTypeService = userTypeService;
        //}

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}