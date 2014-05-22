namespace WebDemo
{
    using System.Web.Routing;
    using App_Start;
    using Felice.Core;
    using Felice.Data;
    using Felice.Mvc;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FeliceCore.Initialize()
                .InitializeDatabase()
                .InitializeMvc();
            
            Database.MigrateToLastVersion();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}