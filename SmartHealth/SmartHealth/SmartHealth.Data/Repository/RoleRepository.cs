using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        SmartHealthEntities _context;
        public RoleRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
    }

    public interface IRoleRepository : IRepository<Role>
    {

    }
}