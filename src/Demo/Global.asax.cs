using System.Web.Mvc;
using System.Web.Routing;

namespace Demo
{
    using Felice.Data;
    using Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyConfig.RegisterDependencies();

            Database.AddMappings(typeof(Project).Assembly);
            Database.AddMigrations(typeof(Project).Assembly);

            Database.MigrateToLastVersion();
        }
    }
}
