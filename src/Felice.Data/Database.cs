namespace Felice.Data
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Core;
    using Felice.Core.Logs;
    using FluentMigrator.Runner;
    using FluentMigrator.Runner.Announcers;
    using FluentMigrator.Runner.Initialization;
    using FluentMigrator.Runner.Processors;
    using NHibernate.Tool.hbm2ddl;

    public class Database
    {
        private static readonly IList<Assembly> mappings = new List<Assembly>();
        private static readonly IList<Assembly> migrations = new List<Assembly>();
        private static bool initialized;
        
        public static IEnumerable<Assembly> Mappings
        {
            get
            {
                return mappings;
            }
        }

        public static IDatabaseProvider Provider
        {
            get
            {
                return Dependency.Resolve<IDatabaseProvider>();
            }
        }

        public static void Initialize()
        {
            if (initialized == false)
            {
                Log.Framework.DebugFormat("Initializing Database");

                if (Provider == null)
                {
                    //// TODO: better exception
                    throw new InvalidOperationException("Database provider was not specified");
                }

                Log.Framework.DebugFormat("Database provider: {0}", Provider.GetType().FullName);
                Log.Framework.DebugFormat("Database Connection: {0}", SettingsConfig.DatabaseConnectionString);

                new HibernateConfiguration().Build(Provider);

                initialized = true;
            }
        }

        public static void AddMappings(Assembly assembly)
        {
            mappings.Add(assembly);
        }

        public static void AddMigrations(Assembly assembly)
        {
            //// TODO: support many migrations assembly
            if (migrations.Count > 1)
            {
                throw new ArgumentException("By now, only one migration assembly is supported");
            }

            migrations.Add(assembly);
        }

        public static void ExportSchema()
        {
            ////new SchemaExport(HibernateConfiguration.BuiltConfiguration).Execute(false, true, false);
            Log.Framework.DebugFormat("Updating schema");
            new SchemaUpdate(HibernateConfiguration.BuiltConfiguration).Execute(false, true);
        }

        public static void MigrateToLastVersion()
        {
            //// TODO: separate schema methods in another class
            
            Log.Framework.DebugFormat("Migrating database schema to last version");

            if (migrations.Count == 0)
            {
                Log.Framework.Warn("No assembly with migrations was found. Use Database.AddMappings(typeof(SomeMigration).Assembly);");
            }

            foreach (var migration in migrations)
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
                var factory = Database.Provider.GetMigratorDriver();
                var processor = factory.Create(SettingsConfig.DatabaseConnectionString, announcer, new ProcessorOptions
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

