using System.Collections.Generic;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}