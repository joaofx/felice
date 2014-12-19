using System.Web.Mvc;
using System.Web.Routing;

namespace Demo
{
    using Felice.Core;
    using Felice.Data;

    /// <summary>
    /// http://stackoverflow.com/questions/22489741/bundle-config-confused-about-debug-and-release-and-minification
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //// MVC Stuff
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //// Registry dependencies
            DependencyConfig.RegisterDependencies();

            //// Boot libraries
            //// Force validate nhibernate mappings before load the application
            FeliceCore.Boot();

            Database.MigrateToLastVersion();
        }
    }
}
