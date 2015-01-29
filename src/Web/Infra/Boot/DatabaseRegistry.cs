using Felice.Data;
using StructureMap.Configuration.DSL;
using Web.Models;

namespace Web.Infra.Boot
{
    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            Database.Configuration.AddMapping(typeof(Product).Assembly);
            Database.Configuration.AddMigration(typeof(Product).Assembly);
        }
    }
}