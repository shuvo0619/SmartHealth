using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Views.ViewModels
{
    public class MessageViewModel
    {
        public virtual Message message{ get; set; }
        public virtual List<Message> messageList{ get; set; }
        
    }
}