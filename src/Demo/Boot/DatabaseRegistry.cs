namespace Demo.Boot
{
    using Felice.Data;
    using Models;
    using StructureMap.Configuration.DSL;

    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            Database.Configuration.AddMappings(typeof(Project).Assembly);
            Database.Configuration.AddMigrations(typeof(Project).Assembly);
        }
    }
}