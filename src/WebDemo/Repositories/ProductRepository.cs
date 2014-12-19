namespace WebDemo.Repositories
{
    using Felice.Data;
    using NHibernate;
    using WebDemo.Models;

    public class ProductRepository : Repository<Product>
    {
        protected ProductRepository(ISession session) : base(session)
        {
        }

        public ProductRepository() : base(null)
        {
            throw new System.NotImplementedException();
        }
    }
}