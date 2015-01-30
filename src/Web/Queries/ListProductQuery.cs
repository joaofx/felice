namespace Web.Queries
{
    using System.Collections.Generic;
    using MediatR;
    using Models;

    public class ListProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}