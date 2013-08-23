namespace Felice.TestFramework
{
    using System;
    using NSubstitute;
    using StructureMap.AutoMocking;

    public class NSubstituteServiceLocator : ServiceLocator
    {
        public T Service<T>() where T : class
        {
            return Substitute.For<T>();
        }

        public object Service(Type serviceType)
        {
            return Substitute.For(new[] { serviceType }, null);
        }

        public T PartialMock<T>(params object[] args) where T : class
        {
            return Substitute.For<T>();
        }
    }
}
