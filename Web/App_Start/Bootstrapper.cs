using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Infrastructure;
using Data.Repositories;
using Service;
using System.Reflection;
using System.Web.Mvc;
using Web.Helpers;

namespace Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerRequest();
            builder.RegisterType<FilmRepository>().As<IFilmRepository>().InstancePerRequest();
            builder.RegisterType<FilmService>().As<IFilmService>().InstancePerRequest();
            builder.RegisterType<GenreHelper>().As<IGenreHelper>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ApplicationDbContext).Assembly)
                .Where(t => t.Name.EndsWith("Context"))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}