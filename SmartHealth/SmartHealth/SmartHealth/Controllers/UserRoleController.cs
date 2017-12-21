using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmartHealth.Controllers
{
    public class UserRoleController : Controller
    {
        #region Global
        private readonly IUserService _UserService;
        private readonly IPatientService _PatientService;
        private readonly IRoleService _RoleService;
        private readonly IUserRoleService _UserRoleService;
        #endregion

        
        #region constructor
        public UserRoleController(IUserService userService, IUserRoleService userRoleService,
            IRoleService roleService, IPatientService patientService)
        {
            this._UserService = userService;
            this._UserRoleService = userRoleService;
            this._RoleService = roleService;
            this._PatientService = patientService;
        }

        #endregion
        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRole()
        {
            ViewBag.RoleId = new SelectList(_UserRoleService.GetAllRole(), "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRole(Role role)
        {
            if (role.RoleId == 1)
            {
                //Session["RoleId"] = userRole.RoleId;
                return RedirectToAction("Create", "Doctor", new { @RoleId = role.RoleId });

            }
            else if (role.RoleId == 2)
            {
                return RedirectToAction("Create", "Patient", new { @RoleId = role.RoleId });
            }
            return View();
        }

        #region GetLogin
        // GET: Registration/Create
        public ActionResult Login()
        {
            //UserAndRole LoginUsr = new UserAndRole();
            //LoginUsr.user.Status = true;

            return View();
        }
        #endregion

        #region PostLogin
        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAndRole LoginUsr)
        {

            UserAndRole userRole = new UserAndRole();

            var authenticatedUser = _UserRoleService.GetUserByUsernameAndPassword(LoginUsr);
            authenticatedUser.user.Status = true;
            bool status = authenticatedUser.user.Status;
            if (authenticatedUser != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = authenticatedUser.UserId.ToString();
                Session["UserName"] = authenticatedUser.user.UserName.ToString();
                Session["FirstName"] = authenticatedUser.user.FirstName.ToString();
                Session["LastName"] = authenticatedUser.user.LastName.ToString();
                Session["RoleId"] = authenticatedUser.role.RoleId.ToString();
                Session["RoleName"] = authenticatedUser.role.RoleName.ToString();
                Session["isauthenticated"] = authenticatedUser.user.isauthenticated;
                Session["Status"] = authenticatedUser.user.Status;

                int UserId = authenticatedUser.UserId;
                string RoleName = authenticatedUser.role.RoleName;
                //return RedirectToAction("UserProfile", new { @UserId = UserId });
                if (RoleName == "Doctor")
                {
                    return RedirectToAction("Index", "Doctor", new { @UserId = UserId, @status = status });
                }
                else if (RoleName == "Patient")
                {
                    return RedirectToAction("PatientProfile", "Patient", new { @UserId = UserId });
                }
         
            }
            else
            {
                LoginUsr.user.isauthenticated = false;
                LoginUsr.user.Status = false;
                ModelState.AddModelError("", "Username or Password is incorrect");
            }
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

        public ActionResult UserProfile(int UserId)
        {

            UserAndRole objUser = new UserAndRole();
            objUser = _UserRoleService.GetUserById(UserId);
            if (objUser != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = objUser.UserId.ToString();
                Session["UserName"] = objUser.user.UserName.ToString();
                Session["FirstName"] = objUser.user.FirstName.ToString();
                Session["LastName"] = objUser.user.LastName.ToString();
                Session["RoleName"] = objUser.role.RoleName;
            }
            return View(objUser);
        }
    }
}