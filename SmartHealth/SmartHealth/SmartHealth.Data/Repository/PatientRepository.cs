using SmartHealth.Data.Infrastructure;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartHealth.Data.Repository
{
    public class PatientRepository: Repository<Patient>, IPatientRepository
    {
        SmartHealthEntities _context;
        public PatientRepository(DbContext context)
            : base(context)
        {
            _context = (SmartHealthEntities)context;
        }
    }

    public interface IPatientRepository : IRepository<Patient>
    {

    }
}