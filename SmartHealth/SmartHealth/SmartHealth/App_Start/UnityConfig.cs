using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using SmartHealth.Data.Repository;
using System.Data.Entity;
using SmartHealth.Data;
using SmartHealth.Data.Infrastructure;
using SmartHealth.Service.Services;

namespace SmartHealth
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<DbContext, SmartHealthEntities>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleService, RoleService>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
            container.RegisterType<IUserRoleService, UserRoleService>();

            container.RegisterType<IMessageRepository, MessageRepository>();
            container.RegisterType<IMessageService, MessageService>();

            container.RegisterType<IDoctorRepository, DoctorRepository>();
            container.RegisterType<IDoctorService, DoctorService>();

            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IPatientService, PatientService>();

            container.RegisterType<IHospitalRepository, HospitalRepository>();
            container.RegisterType<IHospitalService, HospitalService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}