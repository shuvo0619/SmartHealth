using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SmartHealth.Controllers
{
    //[Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        #region Global
        private readonly IUserRoleService _UserRoleService;
        private readonly IRoleService _RoleService;
        private readonly IUserService _UserService;
        private readonly IHospitalService _HospitalService;
        private readonly IPatientService _PatientService;
        private readonly IDoctorService _DoctorService;
        #endregion

         #region constructor
        public PatientController(IUserRoleService userRoleService, IUserService userService,
            IRoleService roleService, IPatientService patientService, IHospitalService hospitalService, IDoctorService doctorService)
        {
            this._UserRoleService = userRoleService;
            this._UserService = userService;
            this._RoleService = roleService;
            this._HospitalService = hospitalService;
            this._PatientService = patientService;
            this._DoctorService = doctorService;
        }

        #endregion

        // GET: Patient
        public ActionResult Index(int id)
        {

            Patient objPatient = new Patient();
            int Id = Convert.ToInt32(id);
            objPatient = _PatientService.GetUserById(Id);
            if (objPatient != null)
            {
                

                Session["UserId"] = objPatient.userAndRole.UserId.ToString();
                Session["UserName"] = objPatient.userAndRole.user.UserName.ToString();
                Session["FirstName"] = objPatient.userAndRole.user.FirstName.ToString();
                Session["LastName"] = objPatient.userAndRole.user.LastName.ToString();
                Session["RoleName"] = objPatient.userAndRole.role.RoleName;
            }
            return View(objPatient);
        }

        
        public ActionResult PatientProfile(int UserId)
        {

            Patient objPatient = new Patient();
            //int Id = Convert.ToInt32(UserId);
            objPatient = _PatientService.GetUserById(UserId);
            if (objPatient != null)
            {
                //FormsAuthentication.SetAuthCookie(LoginUsr.UserName, LoginUsr.RememberMe);

                Session["UserId"] = objPatient.userAndRole.UserId.ToString();
                Session["UserName"] = objPatient.userAndRole.user.UserName.ToString();
                Session["FirstName"] = objPatient.userAndRole.user.FirstName.ToString();
                Session["LastName"] = objPatient.userAndRole.user.LastName.ToString();
                Session["RoleName"] = objPatient.userAndRole.role.RoleName;
            }
            return View(objPatient);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create(int RoleId)
        {
            Role role = new Role();            
            role = _UserRoleService.GetRoleById(RoleId);
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {

            if (ModelState.IsValid)
            {
                _PatientService.AddPatient(patient);
                int UserId = patient.userAndRole.UserId;
                return RedirectToAction("PatientProfile", "Patient", new { @UserId = UserId });
            }
            return View();
        }

        public ActionResult PatientLayout()
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
            Patient objPatientInfo = _PatientService.GetPatientById(id ?? default(int));
            if (objPatientInfo == null)
            {
                return PartialView("_Error");
            }
            return View(objPatientInfo);
        }
        #endregion


        #region Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _PatientService.UpdatePatient(patient);
                int UserId = patient.userAndRole.user.UserId;
                return RedirectToAction("PatientProfile", "Patient", new { @UserId = UserId });
            }
            return View(patient);
        }
        #endregion

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
            //List<Doctor> doctorlist = new List<Doctor>();
            //doctorlist = _DoctorService.GetAllDoctor().ToList();
            //doctorlist.DoctorList = ListOfDoctor;

        }

        public ActionResult Recommendation(int UserId)
        {
            Patient objPatient = new Patient();            
            objPatient = _PatientService.GetUserById(UserId);
            if (objPatient != null)
            {
                Session["Age"] = objPatient.Age;
                Session["Height"] = objPatient.Height;
                Session["Weight"] = objPatient.Weight;
                Session["BloodPressure"] = objPatient.BloodPressure;
                Session["BloodGroup"] = objPatient.BloodGroup;
                Session["Address"] = objPatient.Address;
            }
            return View(objPatient);
        }

        [HttpPost]
        public ActionResult Recommendation()
        {           
            return View();
        }
    }
}
