using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class DoctorRepository: Repository<Doctor>, IDoctorRepository
    {
        SmartHealthEntities _context;
        public DoctorRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
        //public Doctor GetUserByUsernameAndPassword(Doctor LoginUser)
        //{

            
        //    var user = _context.doctor.Where(u => u.user.UserName== LoginUser.user.UserName && u.user.Password == LoginUser.user.Password).FirstOrDefault();
        //    return user;
        //}
    }

    public interface IDoctorRepository : IRepository<Doctor>
    {
        //Doctor GetUserByUsernameAndPassword(Doctor LoginuUser);
    }
}