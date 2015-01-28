namespace Web.Commands
{
    using Felice.Core;
    using MediatR;
    using Models;

    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ProductRepository _productRepository;

        public EditProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Handle(EditProductCommand message)
        {
            var product = new Product
            {
                Name = message.Name, 
                Price = message.Price.ToDecimal2(),
                Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/fmi5feex8yylxst0i5yq.jpg"
            };

            _productRepository.Save(product);

            return product;
        }
    }
}