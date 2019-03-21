using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Infrastructure;
using Data.Repositories;
using System.Reflection;
using System.Web.Mvc;

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

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GenreRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FilmRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ApplicationDbContext).Assembly)
                .Where(t => t.Name.EndsWith("Context"))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerRequest();

            // Services
            //builder.RegisterAssemblyTypes(typeof().Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}