using System.Collections.Generic;

namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ListProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}