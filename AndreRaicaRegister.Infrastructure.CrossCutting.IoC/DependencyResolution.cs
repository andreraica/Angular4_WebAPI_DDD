using AndreRaicaRegister.Application;
using AndreRaicaRegister.Application.Interfaces;
using AndreRaicaRegister.Domain.Services;
using AndreRaicaRegister.Domain.Services.Interfaces;
using AndreRaicaRegister.Infrastructure.Data.Interface;
using AndreRaicaRegister.Infrastructure.Data.Repositories;
using SimpleInjector;

namespace AndreRaicaRegister.Infrastructure.CrossCutting.IoC
{
    public class DependencyResolution
    {
        private static Container _container;

        public static void Register(Container container)
        {
            _container = container;

            RegisterRepositories(Lifestyle.Scoped);
            RegisterApplications(Lifestyle.Scoped);
            RegisterServices(Lifestyle.Scoped);
        }

        static void RegisterApplications(ScopedLifestyle requestLifestyle)
        {
            _container.Register<IUserManager, UserManager>(requestLifestyle);
        }

        static void RegisterServices(ScopedLifestyle requestLifestyle)
        {
            _container.Register<IUserService, UserService>(requestLifestyle);
        }

        static void RegisterRepositories(ScopedLifestyle requestLifestyle)
        {
            _container.Register<IUserRepository, UserRepository>(requestLifestyle);
        }

    }
}
