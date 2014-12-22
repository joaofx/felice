namespace Felice.Data
{
    using System.Collections.Generic;
    using System.Reflection;

    public class DatabaseConfiguration
    {
        private static readonly IList<Assembly> mappings = new List<Assembly>();
        private static readonly IList<Assembly> migrations = new List<Assembly>();

        public IEnumerable<Assembly> Mappings
        {
            get
            {
                return mappings;
            }
        }

        public IEnumerable<Assembly> Migrations
        {
            get
            {
                return migrations;
            }
        }

        public void AddMigration(Assembly assembly)
        {
            migrations.Add(assembly);
        }

        public void AddMapping(Assembly assembly)
        {
            mappings.Add(assembly);
        }
    }
}