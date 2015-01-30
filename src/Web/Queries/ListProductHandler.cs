namespace Web.Queries
{
    using System.Collections.Generic;
    using MediatR;
    using Models;
    using NHibernate;

    public class ListProductHandler : IRequestHandler<ListProductQuery, IEnumerable<Product>>
    {
        private readonly ISession _session;

        public ListProductHandler(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Product> Handle(ListProductQuery message)
        {
            return _session.QueryOver<Product>().List();
        }
    }
}