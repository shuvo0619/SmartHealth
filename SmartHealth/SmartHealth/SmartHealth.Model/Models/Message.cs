using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartHealth.Model.Models
{
    [Table("Message", Schema = "smart")]
    public class Message
    {
        [Key]
        public int ConnectionId { get; set; }
        public int UserId { get; set; }
        public int CurrentId { get; set; }
        public bool SeenOrUnseen { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        public virtual IEnumerable<Message> messageList { get; set; }
    }
}