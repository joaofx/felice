using Felice.Data;
using FluentMigrator.Runner.Processors;
using FluentNHibernate.Cfg.Db;

namespace Web.Infra
{
    using FluentMigrator.Runner.Processors.SqlServer;

    public class SqLiteDatabaseAdapter : IDatabaseAdapter
    {
        public IPersistenceConfigurer GetHibernateDriver(string connectionString)
        {
            return MsSqlCeConfiguration.Standard.ConnectionString(connectionString);
        }

        public MigrationProcessorFactory GetMigratorDriver()
        {
            return new SqlServerCeProcessorFactory();
        }
    }
}