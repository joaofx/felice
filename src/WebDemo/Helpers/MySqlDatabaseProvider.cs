namespace WebDemo.Helpers
{
    using Felice.Data;
    using FluentMigrator.Runner.Processors;
    using FluentMigrator.Runner.Processors.MySql;
    using FluentNHibernate.Cfg.Db;

    public class MySqlDatabaseProvider : IDatabaseProvider
    {
        public IPersistenceConfigurer GetHibernateDriver(string connectionString)
        {
            return MySQLConfiguration.Standard.ConnectionString(connectionString);
        }

        public MigrationProcessorFactory GetMigratorDriver()
        {
            return new MySqlProcessorFactory();
        }
    }
}