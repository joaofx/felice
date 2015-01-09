namespace Demo
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/app.js")
                .Include("~/Content/bower_components/jquery/dist/jquery.js")
                .Include("~/Content/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/app.css")
                .Include("~/Content/bower_components/bootstrap/dist/css/bootstrap.css"));
        }
    }
}