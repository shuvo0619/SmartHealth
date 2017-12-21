using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IHospitalService
    {
        void SaveHospital();
        void AddHospital(Hospital hospital);
        void UpdateHospital(Hospital hospital);
        IEnumerable<Hospital> GetAllHospital();
        
    }

    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _HospitalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HospitalService(IHospitalRepository hospitalRepository,
           IUnitOfWork unitOfWork )
        {
            this._HospitalRepository = hospitalRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SaveHospital()
        {
            _unitOfWork.Commit();
        }

        public void AddHospital(Hospital hospital)
        {
            _HospitalRepository.Add(hospital);
            SaveHospital();
        }

        public void UpdateHospital(Hospital hospital)
        {
            _HospitalRepository.Update(hospital);
            SaveHospital();
        }
        public IEnumerable<Hospital> GetAllHospital()
        {
            return _HospitalRepository.GetAll();
        }
    }
}