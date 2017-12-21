using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartHealth.Model.Models
{
    [Table("Doctor", Schema = "smart")]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public int UserAndRoleId { get; set; }
        public int HospitalId { get; set; }
        public string Designation { get; set; }
        public string Speciality { get; set; }
        public string UniversityName { get; set; }

        [ForeignKey("UserAndRoleId")]
        public virtual UserAndRole userAndRole { get; set; }

        [ForeignKey("HospitalId")]
        public virtual Hospital hospital { get; set; }

        IEnumerable<Doctor> DoctorList { get; set; }
    }
}