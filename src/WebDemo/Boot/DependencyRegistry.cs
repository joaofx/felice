namespace WebDemo.Boot
{
    using Felice.Data;
    using Maps;
    using Migrations;
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

            Database.AddMappings(typeof(ProductMap).Assembly);
            Database.AddMigrations(typeof(CreateProduct).Assembly);
        }
    }
}
