using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class UserRoleRepository: Repository<UserAndRole>, IUserRoleRepository
    {
        SmartHealthEntities _context;
        public UserRoleRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }

        public UserAndRole GetUserByUsernameAndPassword(UserAndRole LoginUser)
        {
            //UserAuthentication usr = new UserAuthentication();
            LoginUser.user.Status = true;
            var usr = _context.userAndRole.Where(u => u.user.UserName == LoginUser.user.UserName && u.user.Password == LoginUser.user.Password).FirstOrDefault();
            return usr;
        }

    }

    public interface IUserRoleRepository : IRepository<UserAndRole>
    {
        UserAndRole GetUserByUsernameAndPassword(UserAndRole LoginuUser);
    }
}