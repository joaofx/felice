namespace Felice.Data
{
    using FluentMigrator.Runner.Processors;
    using FluentMigrator.Runner.Processors.Postgres;
    using FluentNHibernate.Cfg.Db;

    public class PostgreDatabaseAdapter : IDatabaseAdapter
    {
        public IPersistenceConfigurer GetHibernateDriver(string connectionString)
        {
            return PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString);
        }

        public MigrationProcessorFactory GetMigratorDriver()
        {
            return new PostgresProcessorFactory();
        }
    }
}