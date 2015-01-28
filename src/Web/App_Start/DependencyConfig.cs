using System.Web.Mvc;
using Felice.Core;
using Felice.Mvc.IoC;
using MediatR;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.Graph;
using Web.Infra;
using Web.Models;

namespace Web
{
    public class DependencyConfig
    {
        public static Container Container { get; set; }

        public static void RegisterDependencies()
        {
            var container = new Container();
            Container = container;

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

            container.Configure(cfg =>
            {
                cfg.For<ServiceLocatorProvider>().Use(serviceLocatorProvider);
                cfg.For<ProductRepository>().Use(repository);

                cfg.For(typeof(IRequestHandler<,>))
                    .DecorateAllWith(typeof(ValidatorHandler<,>));
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            Dependency.SetupContainer(container);
        }
    }
}