using SmartHealth.Data.Infrastructure;
using SmartHealth.Data.Repository;
using SmartHealth.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHealth.Service.Services
{
    public interface IUserRoleService
    {
        void SaveUserRole();
        void AddUserRole(UserAndRole userType);
        void UpdateUserRole(UserAndRole userType);
        IEnumerable<UserAndRole> GetAllUserRole();
        IEnumerable<Role> GetAllRole();
        Role GetRoleById(int RoleId);
        UserAndRole GetUserById(int UserId);
        UserAndRole GetUserByUsernameAndPassword(UserAndRole LoginUsr);
        
    }

    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IRoleRepository roleRepository,
           IUnitOfWork unitOfWork )
        {
            this._UserRoleRepository = userRoleRepository;
            this._RoleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void SaveUserRole()
        {
            _unitOfWork.Commit();
        }

        public void AddUserRole(UserAndRole userRole)
        {
            _UserRoleRepository.Add(userRole);
            SaveUserRole();
        }

        public void UpdateUserRole(UserAndRole user)
        {
            _UserRoleRepository.Update(user);
            SaveUserRole();
        }
        public IEnumerable<UserAndRole> GetAllUserRole()
        {
            return _UserRoleRepository.GetAll();
        }
        public IEnumerable<Role> GetAllRole()
        {
            return _RoleRepository.GetAll();
        }
        public Role GetRoleById(int RoleId)
        {
            var role = _RoleRepository.Get(r => r.RoleId == RoleId);
            return role;
        }
        public UserAndRole GetUserByUsernameAndPassword(UserAndRole LoginUsr)
        {
            var user = _UserRoleRepository.GetUserByUsernameAndPassword(LoginUsr);
            //user.Status = true;
            return user;
        }
        public UserAndRole GetUserById(int UserId)
        {
            return _UserRoleRepository.Get(r => r.user.UserId == UserId);
        }
    }
}