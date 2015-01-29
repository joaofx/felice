using Felice.Core;
using Felice.Core.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Util;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace Felice.Data.Boot
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            //// TODO: read provider connectionString in app.config
            //For<IDatabaseAdapter>()
            //    .Singleton()
            //    .Use<PostgreDatabaseAdapter>();

            For<FluentConfiguration>().Singleton().Use(x => CreateFluentConfiguration(x));

            For<ISessionFactory>()
                .Singleton()
                .Use(x => CreateSessionFactory(x));

            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x => CreateSession(x));

            For<IUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<UnitOfWork>();
        }

        private static ISession CreateSession(IContext x)
        {
            var session = x.GetInstance<ISessionFactory>().OpenSession();
            session.FlushMode = FlushMode.Commit;
            return session;
        }

        private FluentConfiguration CreateFluentConfiguration(IContext context)
        {
            var databaseProvider = context.GetInstance<IDatabaseAdapter>();

            //// TODO: get list of mappings assembly
            return Fluently
                .Configure()
                .ExposeConfiguration(x => x.SetProperty("cache.use_second_level_cache", "true"))
                .ExposeConfiguration(x => x.SetProperty("cache.use_query_cache", "true"))
                .ExposeConfiguration(x => x.SetProperty("cache.provider_class", typeof(FeliceCacheProvider).AssemblyQualifiedName))
                .Database(databaseProvider.GetHibernateDriver(AppSettings.ConnectionString))
                .Mappings(ConfigureMappings);
        }

        private void ConfigureMappings(MappingConfiguration config)
        {
            Database.Configuration.Mappings.ForEach(map => config.FluentMappings.AddFromAssembly(map));

            config.FluentMappings.Conventions.Add<EnumConvention>();
            config.FluentMappings.Conventions.Add<MonthConvention>();

            config.FluentMappings.Conventions.Add(
                DefaultLazy.Always(),
                DefaultCascade.None(),
                DynamicInsert.AlwaysTrue(),
                DynamicUpdate.AlwaysTrue());
        }

        private ISessionFactory CreateSessionFactory(IContext context)
        {
            return context.GetInstance<FluentConfiguration>().BuildSessionFactory();
        }
    }
}