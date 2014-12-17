namespace Felice.Data
{
    using Core;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Conventions.Helpers;
    using NHibernate.Cfg;

    public class HibernateConfiguration
    {
        public static Configuration BuiltConfiguration
        {
            get;
            private set;
        }

        public Configuration Build(IDatabaseProvider databaseProvider)
        {
            if (BuiltConfiguration == null)
            {
                BuiltConfiguration = Fluently.Configure()
                    .ExposeConfiguration(x => x.SetProperty("cache.use_second_level_cache", "true"))
                    .ExposeConfiguration(x => x.SetProperty("cache.use_query_cache", "true"))
                    .ExposeConfiguration(x => x.SetProperty("cache.provider_class", typeof(FeliceCacheProvider).AssemblyQualifiedName))
                    .Database(databaseProvider.GetHibernateDriver(Core.AppSettings.ConnectionString))
                    .Mappings(m =>
                    {
                        foreach (var mapping in Database.Mappings)
                        {
                            m.FluentMappings.AddFromAssembly(mapping);
                        }
                        ConfigureConventions(m);
                    }).BuildConfiguration();
            }

            return BuiltConfiguration;
        }

        private static void ConfigureConventions(MappingConfiguration m)
        {
            m.FluentMappings.Conventions.Add<EnumConvention>();
            m.FluentMappings.Conventions.Add<MonthConvention>();

            m.FluentMappings.Conventions.Add(
                DefaultLazy.Always(),
                DefaultCascade.None(),
                DynamicInsert.AlwaysTrue(),
                DynamicUpdate.AlwaysTrue());
        }
    }
}