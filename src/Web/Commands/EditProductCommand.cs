namespace Web.Commands
{
    using MediatR;
    using Models;

    public class EditProductCommand : IRequest<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}