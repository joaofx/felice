﻿namespace Demo
{
    using System.Web.Mvc;
    using Felice.Core;
    using Felice.Mvc.IoC;
    using StructureMap;
    using StructureMap.Graph;

    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.Configure(x => x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.LookForRegistries();
                scan.WithDefaultConventions();
            }));

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            Dependency.SetupContainer(container);
        }
    }
}