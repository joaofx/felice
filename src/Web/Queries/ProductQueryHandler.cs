using System.Collections.Generic;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ProductQueryHandler : IRequestHandler<ProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductRepository _productRepository;

        public ProductQueryHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Handle(ProductsQuery message)
        {
            return _productRepository.All();
        }
    }
}