using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IRoleService
    {
        void SaveUserType();
        void AddUserType(Role userType);
        void UpdateUserType(Role userType);
        IEnumerable<Role> GetAllUserType();
        
    }

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository,
           IUnitOfWork unitOfWork )
        {
            this._RoleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SaveUserType()
        {
            _unitOfWork.Commit();
        }

        public void AddUserType(Role userType)
        {
            _RoleRepository.Add(userType);
            SaveUserType();
        }

        public void UpdateUserType(Role userType)
        {
            _RoleRepository.Update(userType);
            SaveUserType();
        }
        public IEnumerable<Role> GetAllUserType()
        {
            return _RoleRepository.GetAll();
        }
    }
}