namespace Felice.UnitTests
{
    using Should;
    using NUnit.Framework;
    using Rhino.Mocks;
    using TestFramework;

    public class MockedUnitTest : MockedTest<MockedUnitTest.FooClass>
    {
        [Test]
        public void Should_return_1()
        {
            this.Get<ISomeDependency>().Stub(x => x.Return()).Return(1);
            this.ClassUnderTest.Return().ShouldEqual(1);
        }

        [Test]
        public void Should_return_2()
        {
            this.Get<ISomeDependency>().Stub(x => x.Return()).Return(2);
            this.ClassUnderTest.Return().ShouldEqual(2);
        }

        public class FooClass
        {
            private readonly ISomeDependency dependency;

            public FooClass(ISomeDependency dependency)
            {
                this.dependency = dependency;
            }

            public int Return()
            {
                return this.dependency.Return();
            }
        }

        public interface ISomeDependency 
        {
            int Return();
        }
    }
}
