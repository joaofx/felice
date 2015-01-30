namespace Web.Infra
{
    using Felice.Data;
    using FluentMigrator.Runner.Processors;
    using FluentMigrator.Runner.Processors.SQLite;
    using FluentNHibernate.Cfg.Db;

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