namespace Felice.TestFramework
{
    using NUnit.Framework;
    using StructureMap.AutoMocking;

    /// <summary>
    /// Unit test a class mocking and injecting dependencies in constructor
    /// </summary>
    /// <typeparam name="T">Class under test</typeparam>
    [TestFixture]
    public abstract class MockedTest<T> : AutoMocker<T> where T : class
    {
        [SetUp]
        public void Setup()
        {
            this._serviceLocator = this.CreateLocator();
            this._container = new AutoMockedContainer(this._serviceLocator); 
   
            this.Scenario();
        }

        public abstract void Scenario();

        private ServiceLocator CreateLocator()
        {
            return new NSubstituteServiceLocator();
        }
    }
}