using System.Collections.Generic;
using NHibernate;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ProductQueryHandler : IRequestHandler<ProductQuery, IEnumerable<Product>>
    {
        private readonly ProductRepository _productRepository;
        private readonly ISession _session;

        public ProductQueryHandler(ProductRepository productRepository, ISession session)
        {
            _productRepository = productRepository;
            _session = session;
        }

        public IEnumerable<Product> Handle(ProductQuery message)
        {
            return _session.QueryOver<Product>().List();
            //return _productRepository.All();
        }
    }
}