using Microsoft.Ajax.Utilities;
using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using SmartHealth.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace SmartHealth.Controllers
{
    public class UserAuthenticationController : Controller
    {
       #region Global
        private readonly IRegistrationService _RegistrationService;
        private readonly IUserTypeService _UserTypeService;
        #endregion

        
        #region constructor
        public UserAuthenticationController(IRegistrationService registrationService,
            IUserTypeService userTypeService)
        {
            this._RegistrationService = registrationService;
            this._UserTypeService = userTypeService;
        }

        #endregion

        #region Index
        // GET: Registration
        public ActionResult Index()
        {
            var user = _RegistrationService.GetUserInformation();
            return View(user);
            
        }
        #endregion


        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        #region GetCreate
        // GET: Registration/Create
        public ActionResult Create()
        {

            ViewBag.RoleId = new SelectList(_UserTypeService.GetAllUserType(), "RoleId", "RoleName");        
            return View();
        }
        #endregion

        #region PostCreate
        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAuthentication registration)
        {
            
            //if(registration.RoleId == 2)
            //{
            //    Session["RoleId"] = registration.RoleId;
            //    return RedirectToAction("Create", "Doctor", new { @RoleId = registration.RoleId });
            //}
            //else if(registration.RoleId == 3)
            //{
            //    return RedirectToAction("Patient","Patient", new { @RoleId = registration.RoleId });
            //}

            //UserRole userRole = new UserRole();
            //ViewBag.RoleId = new SelectList(_UserTypeService.GetAllUserType(), "RoleId", "RoleName");
            //if (ModelState.IsValid)
            //{
                
            //    _RegistrationService.addUser(registration);
            //    var authenticatedUser = _RegistrationService.GetUserByUsernameAndPassword(registration);
            //    int UserId = authenticatedUser.UserId;
            //    string RoleName = authenticatedUser.userRole.RoleName;
            //    if (RoleName == "Doctor")
            //    {
            //        return RedirectToAction("Index", "Doctor", new { @UserId = UserId });
            //    }
            //    else if (RoleName == "Patient")
            //    {
            //        return RedirectToAction("PatientPage", new { @UserId = UserId });
            //    }
            //}
                       
            return View();
        }
        #endregion


        #region GetLogin
        // GET: Registration/Create
        public ActionResult Login()
        {
            UserAuthentication LoginUsr = new UserAuthentication();
            LoginUsr.Status = true;
            
            return View();
        }
        #endregion

        #region PostLogin
        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAuthentication LoginUsr)
        {
            
            UserRole userRole = new UserRole();

            var authenticatedUser = _RegistrationService.GetUserByUsernameAndPassword(LoginUsr);
            authenticatedUser.Status = true;
            bool status = authenticatedUser.Status;
            if (authenticatedUser != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = authenticatedUser.UserId.ToString();
                Session["UserName"] = authenticatedUser.UserName.ToString();
                Session["FirstName"] = authenticatedUser.FirstName.ToString();
                Session["LastName"] = authenticatedUser.LastName.ToString();
                //Session["RoleName"] = authenticatedUser.userRole.RoleName.ToString();
                Session["isauthenticated"] = authenticatedUser.isauthenticated;
                Session["Status"] = authenticatedUser.Status;

                int UserId = authenticatedUser.UserId;
                //string RoleName = authenticatedUser.userRole.RoleName;
                //return RedirectToAction("UserProfile", new { @UserId = UserId });
                //if (RoleName == "Doctor")                
                //{
                //    return RedirectToAction("Index","Doctor", new { @UserId = UserId , @status = status});
                //}
                //else if (RoleName == "Patient")
                //{
                //    return RedirectToAction("PatientPage", new { @UserId = UserId });
                //}
                
            }
            else
            {
                LoginUsr.isauthenticated = false;
                LoginUsr.Status = false;
                ModelState.AddModelError("", "Username or Password is incorrect");
            }
            return View();
        }
        #endregion


        #region GetUserProfile
        // GET: Registration/Create
        public ActionResult DoctorPage(int UserId)
        {
            String[] roles = Roles.GetRolesForUser();

            UserAuthentication usrDoctor = new UserAuthentication();
            //UserProfile objUsrProfile = new UserProfile();
            //objUsrProfile.User = _RegistrationService.GetUserById(UserId);

            usrDoctor = _RegistrationService.GetUserById(UserId);
            usrDoctor.Status = true;
            Session["Id"] = usrDoctor.UserId.ToString();
            Session["UserName"] = usrDoctor.UserName.ToString();
            Session["FirstName"] = usrDoctor.FirstName.ToString();
            Session["LastName"] = usrDoctor.LastName.ToString();
            //Session["UserTypeId"] = usrDoctor.userRole.RoleName.ToString();
            Session["Status"] = usrDoctor.Status;
            return View();
        }
        #endregion

        #region GetUserProfile
        // GET: Registration/Create
        public ActionResult PatientPage(int UserId)
        {
            String[] roles = Roles.GetRolesForUser();


            UserProfile objUsrProfile = new UserProfile();
            objUsrProfile.User = _RegistrationService.GetUserById(UserId);

            Session["Id"] = objUsrProfile.User.UserId.ToString();
            Session["UserName"] = objUsrProfile.User.UserName.ToString();
            Session["FirstName"] = objUsrProfile.User.FirstName.ToString();
            Session["LastName"] = objUsrProfile.User.LastName.ToString();
            //Session["UserTypeId"] = objUsrProfile.User.userRole.RoleName.ToString();
            return View();
        }
        #endregion

        #region Logout
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region LoggedIn
        [HttpGet]
        public ActionResult LoggedIn(int id)
        {
            UserAuthentication LoginUsr = new UserAuthentication();
            //var user = _RegistrationService.GetUserById(User.Identity.GetUserId());
            LoginUsr = _RegistrationService.GetUserById(LoginUsr.UserId);
            return View();
        }
        #endregion

        #region LoggedIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggedIn(UserAuthentication LoginUsr)
        {
           
            if (LoginUsr != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = LoginUsr.UserId.ToString();
                Session["UserName"] = LoginUsr.UserName;
                Session["FirstName"] = LoginUsr.FirstName;
                Session["LastName"] = LoginUsr.LastName;
                //Session["RoleName"] = LoginUsr.userRole.RoleName;
                Session["isauthenticated"] = LoginUsr.isauthenticated;
                Session["Status"] = LoginUsr.Status;

                int UserId = LoginUsr.UserId;
                //string RoleName = LoginUsr.userRole.RoleName;
                //return RedirectToAction("UserProfile", new { @UserId = UserId });
                //if (RoleName == "Doctor")
                //{
                //    return RedirectToAction("Index", "Doctor", new { @UserId = UserId });
                //}
                //else if (RoleName == "Patient")
                //{
                //    return RedirectToAction("PatientPage", new { @UserId = UserId });
                //}
            }
            return View();
        }
        #endregion



        // GET: UserAuthentication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAuthentication/Edit/5
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

        // GET: UserAuthentication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAuthentication/Delete/5
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
