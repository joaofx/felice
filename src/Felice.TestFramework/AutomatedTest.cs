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

            Log.Framework.DebugFormat("Building test scenario executing your IScenarioBuilder");

            var testScenario = Dependency.Resolve<IScenarioBuilder>();
            
            if (testScenario != null)
            {
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