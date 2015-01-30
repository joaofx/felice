using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Felice.Core;
using Felice.Core.Logs;
using Felice.Data;

namespace Web
{
    using System.Data.SqlServerCe;
    using System.IO;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Log.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyConfig.RegisterDependencies();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FeliceCore.Boot();

            //if (File.Exists("4sale_dev.sdf")) File.Delete("4sale_dev.sdf");

            new SqlCeEngine(AppSettings.ConnectionString).CreateDatabase();

            Database.MigrateToLastVersion();
        }
    }
}
