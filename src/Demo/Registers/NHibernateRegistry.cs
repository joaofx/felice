namespace Demo.Registers
{
    using Felice.Core.Model;
    using Felice.Data;
    using StructureMap.Configuration.DSL;
    using StructureMap.Web;

    public class NHibernateRegistry : Registry
    {
        // ... private vars here

        public NHibernateRegistry()
        {
            var cfg = Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2008.ConnectionString(c => 
                        c.FromConnectionStringWithKey("TenantConnectionStringKey")))
                        // where to inject this key?
                .ExposeConfiguration(BuildSchema)
                .Mappings(x => 
                    x.FluentMappings.AddFromAssembly(typeof(UserMap).Assembly)

            For<FluentConfiguration>().Singleton().Use(cfg);

            var sessionFactory = cfg.BuildSessionFactory();

            For<ISessionFactory>().Singleton()
                .Use(sessionFactory);
            For<ISession>().HybridHttpOrThreadLocalScoped()
                .Use(x => x.GetInstance<ISessionFactory>().OpenSession());
            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped()
                .Use<UnitOfWork>();
            For<IDatabaseBuilder>().Use<DatabaseBuilder>();
        }
    }
}