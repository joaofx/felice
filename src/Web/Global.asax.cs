using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    using Felice.Core;
    using Felice.Mvc.IoC;
    using Helpers;
    using MediatR;
    using Microsoft.Practices.ServiceLocation;
    using Models;
    using StructureMap;
    using StructureMap.Graph;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            var container = new Container();

            container.Configure(x => x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(assembly => assembly.FullName.EndsWith(".Tests") == false);
                scan.LookForRegistries();
                scan.WithDefaultConventions();

                scan.AssemblyContainingType<IMediator>();
                scan.AddAllTypesOf(typeof(IRequestHandler<,>));
            }));

            var serviceLocator = new StructureMapServiceLocator(container);
            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);
            var repository = new ProductRepository();

            container.Configure(cfg => cfg.For<ServiceLocatorProvider>().Use(serviceLocatorProvider));
            container.Configure(cfg => cfg.For<ProductRepository>().Use(repository));

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            Dependency.SetupContainer(container);
        }
    }
}
