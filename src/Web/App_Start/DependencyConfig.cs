using System;
using System.IO;
using System.Web.Mvc;
using Felice.Core;
using Felice.Data;
using Felice.Mvc.IoC;
using FluentValidation;
using MediatR;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using StructureMap.Graph;
using Web.Infra;
using Web.Models;
using Web.Queries;

namespace Web
{
    public class DependencyConfig
    {
        public static Container Container { get; set; }

        public static void RegisterDependencies()
        {
            Container = new Container(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory(assembly => assembly.FullName.EndsWith(".Tests") == false);
                    scan.LookForRegistries();

                    scan.AssemblyContainingType<ListProductQuery>();
                    scan.AssemblyContainingType<IMediator>();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf(typeof(IRequestHandler<,>));

                    scan.ConnectImplementationsToTypesClosing(typeof(AbstractValidator<>));
                });

                cfg.For<TextWriter>().Use(Console.Out);

                cfg.For(typeof(IRequestHandler<,>)).DecorateAllWith(typeof(ValidatorHandler<,>));

                cfg.For<IDatabaseAdapter>().Use<SqLiteDatabaseAdapter>();
            });

            var serviceLocator = new StructureMapServiceLocator(Container);
            var serviceLocatorProvider = new ServiceLocatorProvider(() => serviceLocator);

            Container.Configure(cfg => cfg.For<ServiceLocatorProvider>().Use(serviceLocatorProvider));

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(Container));
            Dependency.SetupContainer(Container);
        }
    }
}