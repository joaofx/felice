namespace Felice.TestFramework
{
    using Core;
    using Core.Logs;
    using NUnit.Framework;

    public class AutomatedTest
    {
        static AutomatedTest()
        {
            FeliceCore.Initialize();

            var testScenario = Dependency.Resolve<IScenarioBuilder>();
            
            if (testScenario != null)
            {
                Log.Framework.DebugFormat("Defining test scenario");
                testScenario.Define();
            }
        }

        [TestFixtureSetUp]
        public virtual void BeforeTestFixture()
        {
        }

        [SetUp]
        public virtual void BeforeTest()
        {
        }

        [TearDown]
        public virtual void AfterTest()
        {
        }

        [TestFixtureTearDown]
        public virtual void AfterTestFixture()
        {
        }
    }
}