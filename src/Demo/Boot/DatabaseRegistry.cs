namespace Demo.Boot
{
    using Felice.Data;
    using Models;
    using StructureMap.Configuration.DSL;

    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            Database.Configuration.AddMapping(typeof(Project).Assembly);
            Database.Configuration.AddMigration(typeof(Project).Assembly);
        }
    }
}