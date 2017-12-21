using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SmartHealth.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlainId { get; set; }
        public string PlainPassword { get; set; }
        public string Sha1Password { get; set; }

        public string Md5Password { get; set; }

        public bool IsMasterAdminLogin { get; set; }


        public int EmployeeId { get; set; }

        public bool? IsActive { get; set; }
      

       

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

       

    }


    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
            this.Priority = 0;
        }

        public ApplicationRole(string name)
        {
            this.Priority = 0;
        }

        public virtual string Description { get; set; }
        public int Priority { get; set; }

        
    }

    public class ApplicationUserRole : IdentityUserRole
    {
        public ApplicationUserRole()
            : base()
        { }

        public ApplicationRole Role { get; set; }

    }
}