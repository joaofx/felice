using Felice.Data;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SQLite;
using FluentNHibernate.Cfg.Db;

namespace Web.Infra
{
    public class SqLiteDatabaseAdapter : IDatabaseAdapter
    {
        public IPersistenceConfigurer GetHibernateDriver(string connectionString)
        {
            return SQLiteConfiguration.Standard.ConnectionString(connectionString);
        }

        public MigrationProcessorFactory GetMigratorDriver()
        {
            return new SqliteProcessorFactory();
        }
    }
}