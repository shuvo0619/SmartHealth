using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class HospitalRepository: Repository<Hospital>, IHospitalRepository
    {
        SmartHealthEntities _context;
        public HospitalRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
    }

    public interface IHospitalRepository : IRepository<Hospital>
    {

    }
}