namespace Felice.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Should;
    using Felice.Core;
    using NUnit.Framework;

    public class ListExtensionsTest 
    {
        [Test]
        public void Should_slice_list()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var slices = numbers.EachSlice(3);
            var slice1 = slices.ElementAt(0);
            var slice2 = slices.ElementAt(1);
            var slice3 = slices.ElementAt(2);

            slices.Count().ShouldEqual(3);

            slice1.Count().ShouldEqual(3);
            slice1.ElementAt(0).ShouldEqual(1);
            slice1.ElementAt(1).ShouldEqual(2);
            slice1.ElementAt(2).ShouldEqual(3);

            slice2.Count().ShouldEqual(3);
            slice2.ElementAt(0).ShouldEqual(4);
            slice2.ElementAt(1).ShouldEqual(5);
            slice2.ElementAt(2).ShouldEqual(6);

            slice3.Count().ShouldEqual(2);
            slice3.ElementAt(0).ShouldEqual(7);
            slice3.ElementAt(1).ShouldEqual(8);
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
