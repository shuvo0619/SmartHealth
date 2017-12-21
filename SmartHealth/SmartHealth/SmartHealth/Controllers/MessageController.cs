using SmartHealth.Data;
using SmartHealth.Hubs;
using SmartHealth.Model.Models;
using SmartHealth.Service.Services;
using SmartHealth.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace SmartHealth.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserRoleService _UserRoleService;
        private readonly DoctorService _DoctorService;
        private readonly PatientService _PatientService;
        private readonly IMessageService _MessageService;
        private readonly IUserService _UserService;
        //private ChatHub _ChatHub;

        public MessageController(UserRoleService userRoleService, DoctorService doctorService, PatientService patientService,
            IMessageService messageService, IUserService userService)
        {
            this._UserRoleService = userRoleService;
            this._DoctorService = doctorService;
            this._PatientService = patientService;
            this._MessageService = messageService;
            this._UserService = userService;
            //_ChatHub = new ChatHub();
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage(int UserId)
        {
            Message message = new Message();
            //MessageViewModel msgList = new MessageViewModel();
            var id = Session["UserId"];
            int currentId = Convert.ToInt32(id);
            message.CurrentId = currentId;
            User user = new User();
            message.Date = DateTime.Now;
            user = _UserService.GetUserById(UserId);
            message.user = user;
            message.messageList = _MessageService.GetAllMessage().Where(r => r.CurrentId == UserId && r.UserId == currentId).ToList();
            //ViewBag.listMessage = msgList.messageList;
            
            //message = _MessageService.GetAllMessage().Where(r => r.CurrentId == UserId);
            return View(message);
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {           
            message.Date = DateTime.Now;
            var id = Session["UserId"];
            int currentId = Convert.ToInt32(id);
            if (ModelState.IsValid)
            {
                _MessageService.AddMessage(message);
                int connectionId = message.ConnectionId;
                
                string messageBody = message.MessageBody;
                //return RedirectToAction("messagePartial", "Message", new { @UserId = UserId });               
            }
            int UserId = message.UserId;
            User user = new User();
            user = _UserService.GetUserById(UserId);
            message.user = user;
            message.messageList = _MessageService.GetAllMessage().Where(r => r.CurrentId == message.UserId && r.UserId == currentId).ToList();
            return View(message);
        }

        public PartialViewResult messagePartial(int UserId)
        {
            MessageViewModel msgList = new MessageViewModel();            
            msgList.messageList = _MessageService.GetAllMessage().Where(r => r.CurrentId == UserId).ToList();

            return PartialView("~/Views/Shared/_messagePartial.cshtml", msgList);
        }

        [HttpGet]
        public JsonResult ReceiveMessage(string messageBody, int connectionId, int UserId)
        {
            Message msg = new Message();
            User user = new User();
            user = _UserService.GetUserById(UserId);
            var msge = _MessageService.GetMessage(UserId);
            
            return Json(msge, JsonRequestBehavior.AllowGet);  
        }

        public ActionResult GetMessage(int messageId, int connectionId)
        {           
            var message = _MessageService.GetMessageById(messageId);
            return View(message);
        }

        public ActionResult Chat(int UserId)        
        {
            UserAndRole user = new UserAndRole();
            user = _UserRoleService.GetUserById(UserId);
            ViewBag.Id = UserId;
            //Patient patient = new Patient();            
            //patient = _PatientService.GetPatientById(patient.PatientId);
            //Session["PatientName"] = patient.userAndRole.user.UserName;
            return View(user);
        }
        //[HttpGet]
        //public JsonResult GetNotificationContacts()
        //{
        //    var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
        //    NotificationComponent NC = new NotificationComponent();
        //    var list = NC.GetMessage(notificationRegisterTime);
        //    //update session here for get only new added contacts (notification)
        //    Session["LastUpdate"] = DateTime.Now;
        //    return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public JsonResult GetCountMessage()
        {
            SmartHealthEntities obj = new SmartHealthEntities();
            var id = Session["UserId"];
            int UserCurrentId = Convert.ToInt32(id);
            var contacts = obj.message.Select(x => new
            {
                Id = x.ConnectionId,
                UserId = x.UserId,
                MessageBody = x.MessageBody,
                CurrentId = x.CurrentId,
                Date = x.Date,
                SeenOrUnseen = x.SeenOrUnseen
            }).Where(r => r.UserId == UserCurrentId && r.SeenOrUnseen == false).ToList().Count;
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetAllMessage()  
        {
            SmartHealthEntities obj= new SmartHealthEntities();
            IEnumerable<Message> msg = new List<Message>();
           
            var id = Session["UserId"];
            int UserCurrentId = Convert.ToInt32(id);
            var messageList = obj.message.Where(x => x.UserId == UserCurrentId && x.SeenOrUnseen == false).OrderByDescending(x => x.Date).ToList();
            msg = messageList.Select(a => new Message()
            {
                ConnectionId = a.ConnectionId,
                UserId = a.UserId,
                MessageBody = a.MessageBody,
                CurrentId = a.CurrentId,
                Date = a.Date,
                SeenOrUnseen = a.SeenOrUnseen
            });

            foreach(var item in msg)
            {
                item.SeenOrUnseen = true;
                _MessageService.UpdateMessage(item);
            }
            //var contacts = obj.message.Select(x => new 
            // {  
            //        ConnectionId = x.ConnectionId,  
            //        UserId = x.UserId,  
            //        MessageBody = x.MessageBody,
            //        CurrentId = x.CurrentId,    
            //        Date = x.Date,
            //        SeenOrUnseen = x.SeenOrUnseen
            // }).Where(r => r.UserId == UserCurrentId && r.SeenOrUnseen == false).OrderByDescending(r => r.Date);
           
            //msg = _MessageService.GetMessage(UserCurrentId);
            //msg.SeenOrUnseen = true;
            //_MessageService.UpdateMessage(msg);

            return Json(msg, JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult GetAllMessageList()
        {
            SmartHealthEntities obj = new SmartHealthEntities();


            var id = Session["UserId"];
            int UserCurrentId = Convert.ToInt32(id);
            var contacts = obj.message.Select(x => new
            {
                ConnectionId = x.ConnectionId,
                UserId = x.UserId,
                MessageBody = x.MessageBody,
                CurrentId = x.CurrentId,
                Date = x.Date,
                SeenOrUnseen = x.SeenOrUnseen
            }).Where(r => r.UserId == UserCurrentId && r.SeenOrUnseen == false).OrderByDescending(r => r.Date);

            Message msg = new Message();
            msg = _MessageService.GetMessage(UserCurrentId);
            msg.SeenOrUnseen = true;
            _MessageService.UpdateMessage(msg);

            return Json(contacts.ToList(), JsonRequestBehavior.AllowGet);

        }
  

        public void Delete(int id)
        {
        }
    }
}