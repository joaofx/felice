namespace Web.Queries
{
    using MediatR;
    using Models;

    public class ShowProductQuery : IRequest<Product>
    {
        public long Id { get; set; }
    }
}