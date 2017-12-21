using Microsoft.AspNet.Identity.EntityFramework;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealth.Data.Infrastructure
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {

    }
    public class UsersRepository : Repository<ApplicationUser>, IUsersRepository
    {
        SmartHealthEntities _context;
        public UsersRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
    }
}
