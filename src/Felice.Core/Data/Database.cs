namespace Felice.Core.Data
{
    using System.Collections.Generic;
    using System.Reflection;
    using Logs;
    using NHibernate.Tool.hbm2ddl;

    public class Database
    {
        private static readonly IList<Assembly> mappings = new List<Assembly>();
        private static bool initialized;

        public static IEnumerable<Assembly> Mappings
        {
            get
            {
                return mappings;
            }
        }

        public static void Initialize()
        {
            if (initialized == false)
            {
                Log.Framework.DebugFormat("Initializing Database");
                Log.Framework.DebugFormat("Database Connection: {0}", SettingsConfig.DatabaseConnectionString);

                new HibernateConfiguration().Build();

                initialized = true;
            }
        }

        public static void AddMappings(Assembly assembly)
        {
            mappings.Add(assembly);
        }

        public static void UpdateSchema()
        {
            ////new SchemaExport(HibernateConfiguration.BuiltConfiguration).Execute(false, true, false);
            Log.Framework.DebugFormat("Updating schema");
            new SchemaUpdate(HibernateConfiguration.BuiltConfiguration).Execute(false, true);
        }
    }
}

