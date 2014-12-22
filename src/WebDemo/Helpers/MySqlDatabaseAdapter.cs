namespace WebDemo.Helpers
{
    using Felice.Data;
    using FluentMigrator.Runner.Processors;
    using FluentMigrator.Runner.Processors.MySql;
    using FluentNHibernate.Cfg.Db;

    public class MySqlDatabaseAdapter : IDatabaseAdapter
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