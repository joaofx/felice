using System.Collections.Generic;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}