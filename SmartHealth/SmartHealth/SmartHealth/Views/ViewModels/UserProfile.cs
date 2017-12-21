using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Views.ViewModels
{
    public class UserProfile
    {
        public virtual User User { get; set; }
        public virtual IEnumerable<Doctor> DoctorList { get; set; }
        public virtual  bool? DoctorStatus { get; set; }
      
    }
}