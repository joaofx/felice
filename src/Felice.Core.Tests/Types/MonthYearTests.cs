namespace Felice.UnitTests.Types
{
    using Should;
    using System;
    using Felice.Core.Types;
    using NUnit.Framework;
    using TestFramework;

    [TestFixture]
    public class MonthYearTests : UnitTest
    {
        [Test]
        public void Should_parse()
        {
            new Month(DateTime.Parse("01/05/2013")).ShouldEqual(new Month("05/2013"));
        }

        [Test]
        public void Should_create()
        {
            new Month("05/2013").ShouldEqual(new Month("05/2013"));
        }
    }
}
