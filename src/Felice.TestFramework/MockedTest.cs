namespace Felice.TestFramework
{
    using NUnit.Framework;
    using StructureMap.AutoMocking;

    /// <summary>
    /// Unit test a class mocking and injecting dependencies in constructor
    /// </summary>
    /// <typeparam name="T">Class under test</typeparam>
    [TestFixture]
    public abstract class MockedTest<T> where T : class
    {
        protected RhinoAutoMocker<T> mock;

        [SetUp]
        public void Setup()
        {
            this.mock = new RhinoAutoMocker<T>(MockMode.AAA);
            this.Scenario();
        }

        public virtual void Scenario()
        {
        }

        protected T ClassUnderTest
        {
            get { return this.mock.ClassUnderTest; }
        }

        protected TMock Get<TMock>() where TMock : class
        {
            return this.mock.Get<TMock>();
        }
    }
}