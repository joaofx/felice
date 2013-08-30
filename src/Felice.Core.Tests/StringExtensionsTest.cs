namespace Felice.UnitTests
{
    using Felice.Core;
    using NBehave.Spec.NUnit;
    using NUnit.Framework;
    using TestFramework;

    public class StringExtensionsTest : UnitTest
    {
        [Test]
        public void Should_return_if_string_is_equal_one_or_more_string()
        {
            "one".IsEqual("one", "two", "three").ShouldBeTrue();
            "two".IsEqual("one", "two", "three").ShouldBeTrue();
            "three".IsEqual("one", "two", "three").ShouldBeTrue();
            "ten".IsEqual("one", "two").ShouldBeFalse();
        }

        [Test]
        public void Should_return_right_of_string()
        {
            "one".Right().ShouldEqual("e");
            "two".Right().ShouldEqual("o");
            "ten".Right().ShouldEqual("n");
            "".Right().ShouldEqual("");
        }
    }
}
