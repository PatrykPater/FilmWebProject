using Autofac;
using Autofac.Integration.WebApi;
using Data;
using Data.Infrastructure;
using Data.Repositories;
using Service;
using System.Reflection;
using System.Web.Http;
using Web.Helpers;

namespace Web
{
    public class BootstrapperApi
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

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
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}