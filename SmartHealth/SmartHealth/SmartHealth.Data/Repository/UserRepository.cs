using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        SmartHealthEntities _context;
        public UserRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }

        public User GetUserByUsernameAndPassword(User LoginUser)
        {
            //UserAuthentication usr = new UserAuthentication();
            LoginUser.Status = true;
            var usr = _context.user.Where(u => u.UserName == LoginUser.UserName && u.Password == LoginUser.Password).FirstOrDefault();            
            return usr;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsernameAndPassword(User LoginuUser);
    }
}