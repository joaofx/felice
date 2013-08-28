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

        public static void AddMigrations(Assembly assembly)
        {
            if (migrations.Count > 1)
            {
                throw new ArgumentException("By now only one migration assembly is supported");
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
            foreach (var migration in migrations)
            {
                var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
                var assembly = migration;

                var migrationContext = new RunnerContext(announcer);
                var factory = new FluentMigrator.Runner.Processors.Postgres.PostgresProcessorFactory();
                var processor = factory.Create(SettingsConfig.DatabaseConnectionString, announcer, new ProcessorOptions
                {
                    Timeout = 60,
                    PreviewOnly = false
                });

                var runner = new MigrationRunner(assembly, migrationContext, processor);

                runner.MigrateUp();
            }
        }
    }
}
