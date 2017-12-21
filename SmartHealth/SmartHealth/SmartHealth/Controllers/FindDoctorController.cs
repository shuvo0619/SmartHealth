using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using SmartHealth.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHealth.Controllers
{
    public class FindDoctorController : Controller
    {
        #region Global
        private readonly IRegistrationService _RegistrationService;

        #endregion

         #region constructor
        public FindDoctorController(IRegistrationService registrationService)
        {
            this._RegistrationService = registrationService;            
        }

        #endregion

        // GET: FindDoctor
        //public ActionResult Index(IEnumerable<UserAuthentication> ListOfDoctor)
        //{
            
        //    UserProfile doctorlist = new UserProfile();
        //    ListOfDoctor = _RegistrationService.GetDoctorList().ToList();
        //    doctorlist.DoctorList = ListOfDoctor;
           
        //    return View(doctorlist);
        //}

        // GET: FindDoctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FindDoctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FindDoctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAuthentication usr)
        {
            return View();
        }

        // GET: FindDoctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FindDoctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FindDoctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FindDoctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
