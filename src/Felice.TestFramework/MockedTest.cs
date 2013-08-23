namespace Felice.TestFramework
{
    using StructureMap.AutoMocking;

    public class MockedTest<T> : AutoMocker<T> where T : class
    {
        public MockedTest()
        {
            this._serviceLocator = this.CreateLocator();
            this._container = new AutoMockedContainer(this._serviceLocator);
        }

        private ServiceLocator CreateLocator()
        {
            return new NSubstituteServiceLocator();
        }
    }
}