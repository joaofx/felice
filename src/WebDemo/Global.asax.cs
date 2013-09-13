using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebDemo
{
    using App_Start;
    using Felice.Core;
    using Felice.Data;
    using Felice.Mvc;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FeliceCore.Initialize().InitializeDatabase().InitializeMvc();
            
            Database.MigrateToLastVersion();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}