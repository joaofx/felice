namespace Demo.Tests.Integration
{
    using Felice.TestFramework;
    using FluentNHibernate.Testing;
    using NUnit.Framework;
    using WebDemo.Models;

    [TestFixture]
    public class ProductMapTest : MappingTest
    {
        [Test]
        public void Should_save_entity()
        {
            this.Entity<Product>()
                .CheckProperty(x => x.Name, "iPhone 5")
                .CheckProperty(x => x.Price, 400.99m)
                .VerifyTheMappings();
        }
    }
}
