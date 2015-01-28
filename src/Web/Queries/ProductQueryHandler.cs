using System.Collections.Generic;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ProductQueryHandler : IRequestHandler<ProductQuery, IEnumerable<Product>>
    {
        private readonly ProductRepository _productRepository;

        public ProductQueryHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Handle(ProductQuery message)
        {
            return _productRepository.All();
        }
    }
}