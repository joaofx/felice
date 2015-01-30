namespace Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Felice.Core;
    using Felice.Core.Logs;
    using Felice.Data;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Log.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyConfig.RegisterDependencies();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FeliceCore.Boot();

            Database.MigrateToLastVersion();
        }
    }
}