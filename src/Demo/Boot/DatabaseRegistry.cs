namespace Demo.Boot
{
    using Felice.Data;
    using Models;
    using StructureMap.Configuration.DSL;

    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            Database.Configuration.AddMapping(typeof(Food).Assembly);
            Database.Configuration.AddMigration(typeof(Food).Assembly);
        }
    }
}