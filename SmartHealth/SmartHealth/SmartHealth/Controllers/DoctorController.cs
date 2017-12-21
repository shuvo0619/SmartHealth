using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using SmartHealth.Views.ViewModels;
//using SmartHealth.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SmartHealth.Controllers
{
    //[Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        #region Global
        private readonly IUserRoleService _UserRoleService;
        private readonly IRoleService _RoleService;
        private readonly IUserService _UserService;
        private readonly IHospitalService _HospitalService;
        private readonly IDoctorService _DoctorService;
        #endregion

        
        #region constructor
        public DoctorController(IUserRoleService userRoleService, IUserService userService,
            IRoleService roleService, IDoctorService doctorService, IHospitalService hospitalService)
        {
            this._UserRoleService = userRoleService;
            this._UserService = userService;
            this._RoleService = roleService;
            this._HospitalService = hospitalService;
            this._DoctorService = doctorService;
        }

        #endregion
        // GET: Doctor
        public ActionResult Index(int UserId, bool status)
        {
            Doctor objDoctor = new Doctor();
            objDoctor = _DoctorService.GetUserById(UserId);
            if (objDoctor != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = objDoctor.userAndRole.UserId.ToString();
                Session["UserName"] = objDoctor.userAndRole.user.UserName.ToString();
                Session["FirstName"] = objDoctor.userAndRole.user.FirstName.ToString();
                Session["LastName"] = objDoctor.userAndRole.user.LastName.ToString();
                Session["RoleName"] = objDoctor.userAndRole.role.RoleName;
                //Session["Status"] = status;
            }
            return View(objDoctor);
  
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       
        // GET: Doctor/Create
        public ActionResult Create(int RoleId)
        {
            Role role = new Role();
            ViewBag.HospitalId = new SelectList(_HospitalService.GetAllHospital(), "HospitalId", "HospitalName");
            role = _UserRoleService.GetRoleById(RoleId);
            return View();
            //user.RoleId = RoleId;            
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doctor)
        {
            
            //ViewBag.HospitalId = new SelectList(_HospitalService.GetAllHospital(), "HospitalId", "HospitalName");
            //ViewBag.RoleId = new SelectList(_UserRoleService.GetAllRole(), "RoleId", "RoleName");
            //var id = _UserRoleService.GetRoleById(doctor.userAndRole.RoleId);
            
            if (ModelState.IsValid)
            {
                _DoctorService.AddDoctor(doctor);
                int UserId = doctor.userAndRole.UserId;
                doctor.userAndRole.user.Status = true;
                bool status = doctor.userAndRole.user.Status;
                Session["Status"] = doctor.userAndRole.user.Status;
                return RedirectToAction("Index", "Doctor", new { @UserId = UserId, @status = status });
            }
            return View();
        }

        [HttpPost]
        public JsonResult GetRole(int RoleId)
        {

            var roleId = _UserRoleService.GetRoleById(RoleId);
            return Json(roleId, JsonRequestBehavior.AllowGet);

        }

         //GET: FindDoctor
        [HttpGet]
        public ViewResult FindDoctor(int? page, int? size)
        {
            TempData["page"] = page;
            TempData["size"] = size;
            ViewBag.size = size;
            ViewBag.page = page;

            var DoctorList = _DoctorService.GetAllDoctor().ToList();
            
            if (size > 0)
            {

                int pageSiz = Convert.ToInt32(size);
                int pageNumbe = (page ?? 1);
                return View(DoctorList.ToPagedList(pageNumbe, Convert.ToInt16(size)));
            }
            else
            {
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(DoctorList.ToPagedList(pageNumber, pageSize));
            }

        }

        // GET: Doctor/ViewProfile
        [HttpGet]
        public ActionResult ViewProfile(int? id)
        {            
            if (id == null)
            {
                return PartialView("_Error");
            }

            Doctor doctorInfo = _DoctorService.GetDoctorById(id ?? default(int));
            if (doctorInfo == null)
            {
                return PartialView("_Error");
            }
            return PartialView(doctorInfo);           
        }

        public ActionResult DoctorLayout()
        {
            return View();
        }

        #region doctor edit
        // GET: Doctor/Edit/5
         [HttpGet]       
        public ActionResult Edit(int? id)
        {          
            if (id == null)
            {
                return PartialView("_Error");
            }
            Doctor objDoctorInfo = _DoctorService.GetDoctorById(id ?? default(int));
            if (objDoctorInfo == null)
            {
                return PartialView("_Error");
            }
            
             ViewBag.HospitalId = new SelectList(_HospitalService.GetAllHospital(),"HospitalId", "HospitalName", objDoctorInfo.HospitalId);
             return View(objDoctorInfo);
        }
        #endregion


        #region Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _DoctorService.UpdateDoctor(doctor);
                int UserId = doctor.userAndRole.user.UserId;
                var status = Session["Status"];
                return RedirectToAction("Index", "Doctor", new { @UserId = UserId, @status = status});
            }
            return View(doctor);
        }
        #endregion

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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
