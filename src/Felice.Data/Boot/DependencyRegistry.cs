﻿namespace Felice.Data.Boot
{
    using StructureMap.Configuration.DSL;

    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            this.Scan(x =>
            {
                x.AssemblyContainingType<DependencyRegistry>();
                x.WithDefaultConventions();
            });
        }
    }
}
