namespace Felice.Mvc
{
    using System.Web.Mvc;
    using Felice.Core;
    using IoC;

    public static class Initialization
    {
        public static IFeliceInitialization InitializeMvc(this IFeliceInitialization init)
        {
            return init
                .InitializeMvcDependencyResolver()
                .InitializeMvcFilters()
                .InitializeMvcViewEngine();
        }

        public static IFeliceInitialization InitializeMvcDependencyResolver(this IFeliceInitialization init)
        {
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
            FilterProviders.Providers.Add(new StructureMapFilterAttributeFilterProvider());
            return init;
        }

        public static IFeliceInitialization InitializeMvcFilters(this IFeliceInitialization init)
        {
            GlobalFilters.Filters.Add(new UnitOfWorkFilter());
            return init;
        }

        public static IFeliceInitialization InitializeMvcViewEngine(this IFeliceInitialization init)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            return init;
        }
    }
}

