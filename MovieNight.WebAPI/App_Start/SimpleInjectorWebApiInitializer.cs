

[assembly: WebActivator.PostApplicationStartMethod(typeof(MovieNight.WebAPI.SimpleInjectorWebApiInitializer), "Initialize")]

namespace MovieNight.WebAPI
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using MovieNight.Domain.Interfaces;
    using MovieNight.Domain.Repositories.EntityFramework;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IMoviesRepository, MoviesRepository>(Lifestyle.Scoped);
            container.RegisterSingleton<EntityFrameworkDbContext>();
        }
    }
}