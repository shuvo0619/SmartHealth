using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data
{
    public class SmartHealthEntities : DbContext
    {
        public SmartHealthEntities() : base("name = SmartHealth_Entities")
        {

        }

        public DbSet<Role> role { get; set; }
        public DbSet<User> user{ get; set; }
        public DbSet<UserAndRole> userAndRole { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Patient> patient { get; set; }
        public DbSet<Hospital> hospital { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Message> message { get; set; }
        
    }
}