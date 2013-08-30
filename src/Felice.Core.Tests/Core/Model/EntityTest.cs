namespace Felice.UnitTests.Core.Model
{
    using Felice.Core.Model;
    using NBehave.Spec.NUnit;
    using NUnit.Framework;
    using TestFramework;

    public class EntityTest : UnitTest
    {
        [Test]
        public void Entities_with_same_id_should_be_equal()
        {
            new Foo(1).ShouldEqual(new Foo(1));
            (new Foo(1) == new Foo(1)).ShouldBeTrue();
        }

        [Test]
        public void Entities_with_different_id_should_not_be_equal()
        {
            new Foo(1).ShouldNotEqual(new Foo(2));
            (new Foo(1) == new Foo(2)).ShouldBeFalse();
        }

        [Test]
        public void New_entities_should_not_be_equal()
        {
            new Foo().ShouldNotEqual(new Foo());
        }

        [Test]
        public void Hashcode_should_be_different_from_id()
        {
            new Foo(1).GetHashCode().ShouldNotEqual(1);
        }
    }

    public class Foo : Entity
    {
        public Foo()
        {
        }

        public Foo(int id)
        {
            this.Id = id;
        }
    }
}
