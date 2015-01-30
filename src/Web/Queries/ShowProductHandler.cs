namespace Web.Queries
{
    using MediatR;
    using Models;
    using NHibernate;

    public class ShowProductHandler : IRequestHandler<ShowProductQuery, Product>
    {
        private readonly ISession _session;

        public ShowProductHandler(ISession session)
        {
            _session = session;
        }

        public Product Handle(ShowProductQuery message)
        {
            return _session.Get<Product>(message.Id);
        }
    }
}