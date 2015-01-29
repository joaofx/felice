namespace Felice.Data
{
    using System;
    using System.Linq;
    using Core;
    using Felice.Core.Logs;
    using FluentMigrator.Runner;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;
    using FluentMigrator.Runner.Processors;

    public class Database
    {
        private static bool _initialized;

        static Database()
        {
            Configuration = new DatabaseConfiguration();    
        }
        
        public static DatabaseConfiguration Configuration
        {
            get;
            private set;
        }

        public static DatabaseMigrator Migrator
        {
            get
            {
                return Dependency.Container.GetInstance<DatabaseMigrator>();
            }
        }

        public static void Initialize()
        {
            if (_initialized == false)
            {
                Log.Framework.DebugFormat("Initializing Database");

                //Log.Framework.DebugFormat("Database provider: {0}", Provider.GetType().FullName);
                //Log.Framework.DebugFormat("Database Connection: {0}", AppSettings.ConnectionString);

                _initialized = true;
            }
        }

        public static void ExportSchema()
        {
            ////new SchemaExport(HibernateConfiguration.BuiltConfiguration).Execute(false, true, false);
            ////Log.Framework.DebugFormat("Updating schema");
            ////new SchemaUpdate(HibernateConfiguration.BuiltConfiguration).Execute(false, true);
        }

        public static void MigrateToLastVersion()
        {
            //// TODO: separate schema methods in another class
            var provider = Dependency.Resolve<IDatabaseAdapter>();

            Log.Framework.DebugFormat("Migrating database schema to last version");

            if (Database.Configuration.Migrations.Any() == false)
            {
                Log.Framework.Warn("No assembly with migrations was found. Use Database.AddMapping(typeof(SomeMigration).Assembly);");
            }

            foreach (var migration in Database.Configuration.Migrations)
            {
                Log.Framework.DebugFormat("Migrating {0}", migration.FullName);

                var announcer = new TextWriterAnnouncer(s =>
                {
                    s = s.Replace(Environment.NewLine, string.Empty);

                    if (string.IsNullOrEmpty(s) == false)
                    {
                        Log.Framework.DebugFormat(s);    
                    }
                });

                var assembly = migration;

                var migrationContext = new RunnerContext(announcer);
                var factory = provider.GetMigratorDriver();
                var processor = factory.Create(AppSettings.ConnectionString, announcer, new ProcessorOptions
                {
                    Timeout = 60,
                    PreviewOnly = false
                });

                var runner = new MigrationRunner(assembly, migrationContext, processor);

                runner.MigrateUp();
            }

            Log.Framework.DebugFormat("Database migrated");
        }
    }
}

