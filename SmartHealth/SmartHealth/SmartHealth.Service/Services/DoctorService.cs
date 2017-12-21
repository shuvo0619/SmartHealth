using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IDoctorService
    {
        void SaveDoctor();
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        IEnumerable<Doctor> GetAllDoctor();
        IEnumerable<Doctor> GetUserInformation();
        //Doctor GetUserByUsernameAndPassword(Doctor LoginUsr);
        Doctor GetUserById(int id);
        IEnumerable<Doctor> GetDoctorList();
        IEnumerable<Doctor> GetUserInformationbyId(int id);
        Doctor GetDoctorById(int id);
        
    }

    public class DoctorService : IDoctorService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly IDoctorRepository _DoctorRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository,
           IUnitOfWork unitOfWork, IDoctorRepository DoctorRepository, IUserRepository userRepository)
        {
            this._UserRoleRepository = userRoleRepository;
            this._DoctorRepository = DoctorRepository;
            this._UserRepository = userRepository;
            this._RoleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SaveDoctor()
        {
            _unitOfWork.Commit();
        }

        public void AddDoctor(Doctor doctor)
        {
            _DoctorRepository.Add(doctor);
            SaveDoctor();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _DoctorRepository.Update(doctor);
            SaveDoctor();
        }
        public IEnumerable<Doctor> GetAllDoctor()
        {
            return _DoctorRepository.GetAll();
        }

        public IEnumerable<Doctor> GetUserInformation()
        {
            return _DoctorRepository.GetAll().ToList();
        }

        public IEnumerable<Doctor> GetUserInformationbyId(int id)
        {
            return _DoctorRepository.GetMany(r => r.UserAndRoleId == id);
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _DoctorRepository.Get(r => r.DoctorId == id);
            return doctor;
        }

        public Doctor GetUserById(int UserId)
        {
            return _DoctorRepository.Get(r => r.userAndRole.UserId == UserId);
        }


        public IEnumerable<Doctor> GetDoctorList()
        {
            return _DoctorRepository.GetAll();
        }
    }
}