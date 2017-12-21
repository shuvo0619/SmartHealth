using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartHealth.Model.Models
{
    [Table("Patient", Schema = "smart")]
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public int UserAndRoleId { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string BloodGroup { get; set; }
        public string Address { get; set; }

        [ForeignKey("UserAndRoleId")]
        public virtual UserAndRole userAndRole { get; set; }
    }
}