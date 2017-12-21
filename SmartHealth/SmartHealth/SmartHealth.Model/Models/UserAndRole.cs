using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartHealth.Model.Models
{
    [Table("UserAndRole", Schema = "smart")]
    public class UserAndRole
    {
        
        [Key]
        public int UserAndRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role role { get; set; }
    }
}