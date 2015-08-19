using Demo.Models;
using FluentNHibernate.Testing;

namespace Demo.Tests.Integration
{
    using Felice.TestFramework;
    using NUnit.Framework;

    [TestFixture]
    public class FoodMapTest : MappingTest
    {
        [Test]
        public void Should_save_entity()
        {
            Entity<Food>()
                .CheckProperty(x => x.Name, "Cheese")
                .CheckProperty(x => x.Calories, 2.99m)
                .CheckProperty(x => x.Carbs, 2.91m)
                .CheckProperty(x => x.Fats, 2.3m)
                .CheckProperty(x => x.Proteins, 2.11m)
                .VerifyTheMappings();
        }
    }
}
