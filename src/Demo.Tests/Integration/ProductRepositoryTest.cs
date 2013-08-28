namespace Demo.Tests.Integration
{
    using Felice.TestFramework;
    using NUnit.Framework;
    using WebDemo.Models;
    using WebDemo.Repositories;

    [TestFixture]
    public class ProductRepositoryTest : RepositoryTest<Product, ProductRepository>
    {
        public override Product CreateEntity()
        {
            return new Product();
        }
    }
}
