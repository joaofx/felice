namespace Web.Queries
{
    using System.Collections.Generic;
    using NHibernate;
    using MediatR;
    using Models;

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