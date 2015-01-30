namespace Web.Infra.Boot
{
    using Features.Product;
    using Felice.Data;
    using StructureMap.Configuration.DSL;

    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            Database.Configuration.AddMapping(typeof (Product).Assembly);
            Database.Configuration.AddMigration(typeof (Product).Assembly);
        }
    }
}