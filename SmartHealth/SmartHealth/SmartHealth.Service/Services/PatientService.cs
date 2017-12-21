using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IPatientService
    {
        void SavePatient();
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        IEnumerable<Patient> GetAllPatient();
        Patient GetPatientById(int Id);
        Patient GetUserById(int UserId);
    }

    public class PatientService : IPatientService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IPatientRepository _PatientRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUserRoleRepository userRoleRepository,IUnitOfWork unitOfWork, 
            IPatientRepository PatientRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this._UserRoleRepository = userRoleRepository;
            this._PatientRepository = PatientRepository;
            this._UserRepository = userRepository;
            this._RoleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SavePatient()
        {
            _unitOfWork.Commit();
        }

        public void AddPatient(Patient patient)
        {
            _PatientRepository.Add(patient);
            SavePatient();
        }

        public void UpdatePatient(Patient patient)
        {
            _PatientRepository.Update(patient);
            SavePatient();
        }
        public IEnumerable<Patient> GetAllPatient()
        {
            return _PatientRepository.GetAll();
        }
        public Patient GetPatientById(int Id)
        {
            return _PatientRepository.Get(r => r.PatientId == Id);
        }

        public Patient GetUserById(int UserId)
        {
            return _PatientRepository.Get(r => r.userAndRole.UserId == UserId);
        }
    }
}