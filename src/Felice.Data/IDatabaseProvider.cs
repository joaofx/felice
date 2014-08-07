namespace Felice.Data
{
    using FluentMigrator.Runner.Processors;
    using FluentNHibernate.Cfg.Db;

    public interface IDatabaseProvider
    {
        IPersistenceConfigurer GetHibernateDriver(string connectionString);

        MigrationProcessorFactory GetMigratorDriver();
    }
}