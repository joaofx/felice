namespace Demo.AcceptanceTests
{
    using NUnit.Framework;
    using SpecsFor.Mvc;

    [SetUpFixture]
    public class AcceptanceTestBase
    {
        private static SpecsForIntegrationHost integrationHost;

        /// <summary>
        /// <p>
        /// This hook runs at the end of the entire test run.
        /// It's analogous to an MSTest method decorated with the
        /// <see cref="Microsoft.VisualStudio.TestingTools.UnitTesting.AssemblyCleanupAttribute" />
        /// attribute.
        /// </p>
        /// <p>
        /// NOTE: Not all test runners have the notion of a test run cleanup.
        /// If using MSTest, this probably gets run in a method decorated with
        /// the attribute mentioned above. For other test runners, this method
        /// may not execute until the test DLL is unloaded. YMMV.
        /// </p>
        /// </summary>
        [TearDown]
        public void CleanUpTestRun()
        {
            integrationHost.Shutdown();
        }

        /// <summary>
        /// <p>
        /// This hook runs at the beginning of an entire test run.
        /// It's equivalent to an MSTest method decorated with the
        /// <see cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute />
        /// attribute.
        /// </p>
        /// <p>
        /// NOTE: Not all test runners have a notion of an assembly
        /// initializer or test run initializer, YMMV.
        /// </p>
        /// </summary>
        [SetUp]
        public static void InitializeTestRun()
        {
            var config = new SpecsForMvcConfig();

            config.UseIISExpress()
                .With(Project.Named("Demo"))
                .ApplyWebConfigTransformForConfig("Debug");

            config.BuildRoutesUsing(r => RouteConfig.RegisterRoutes(r));

            // If you want to be authenticated for each request, 
            // implement IHandleAuthentication
            //config.AuthenticateBeforeEachTestUsing<SampleAuthenticator>();

            // I originally tried to use Chrome, but the Selenium 
            // Chrome WebDriver, but it must be out of date because 
            // Chrome gave me an error and the tests didn't run (NOTE: 
            // I used the latest Selenium NuGet package as of
            // 23-08-2014). However, Firefox worked fine, so I used that.
            config.UseBrowser(BrowserDriver.Firefox);

            integrationHost = new SpecsForIntegrationHost(config);
            integrationHost.Start();
        }

        ///// <summary>
        ///// This hook runs once before any of the SpecFlow feature's
        ///// scenarios are run and stores a <see cref="SpecsFor.Mvc.MvcWebApp />
        ///// instance in the <see cref="TechTalk.SpecFlow.FeatureContext" />
        ///// for the feature.
        ///// </summary>
        //[SetUp]
        //public static void CreateFeatureMvcWebApp()
        //{
        //    MvcWebApp theApp;
        //    if (!FeatureContext.Current.TryGetValue<MvcWebApp>(out theApp))
        //        FeatureContext.Current.Set<MvcWebApp>(new MvcWebApp());
        //}
    }
}