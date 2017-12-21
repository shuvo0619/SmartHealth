using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartHealth.Model.Models
{
    [Table("VideoCalling", Schema = "smart")]
    public class VideoCalling
    {
        [Key]
        public int ConnectionId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }

    }
}