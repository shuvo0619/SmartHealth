using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IUserService
    {
        void addUser(User registration);
        void Save();
        IEnumerable<User> GetUserInformation();
        
        User GetUserByUsernameAndPassword(User LoginUsr);
        User GetUserById(int UserId);
        //IEnumerable<UserAuthentication> GetDoctorList();
        IEnumerable<User> GetUserInformationbyId(int id);
        User GetActiveDoctor(int id, bool status);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,
           IUnitOfWork unitOfWork )
        {
            this._UserRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public void addUser(User registration)
        {
            // var PP = _UserAuthenticationRepository.GetAll();

            _UserRepository.Add(registration);
            Save();
        }

        public void Save()
        {
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<User> GetUserInformation()
        {
            return _UserRepository.GetAll().ToList();
        }

        public IEnumerable<User> GetUserInformationbyId(int id)
        {
            return _UserRepository.GetMany(r => r.UserId == id);
        }

        public User GetUserByUsernameAndPassword(User LoginUsr)
        {
            var user = _UserRepository.GetUserByUsernameAndPassword(LoginUsr);
            //user.Status = true;
            return user;
        }

        public User GetUserById(int UserId)
        {
            return _UserRepository.Get(r => r.UserId == UserId);
        }

        public User GetActiveDoctor(int id, bool status)
        {
            return _UserRepository.Get(r => r.UserId == id && r.Status == status);
        }
        //public IEnumerable<UserAuthentication> GetDoctorList()
        //{
        //    var doctorList = _RegistrationRepository.GetMany(r => r.userRole.RoleId == 2).ToList();
            
        //    return doctorList;
        //}

        
    }
}