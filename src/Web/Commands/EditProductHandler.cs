using NHibernate;

namespace Web.Commands
{
    using Felice.Core;
    using MediatR;
    using Models;

    public class EditProductHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ISession _session;

        public EditProductHandler(ISession session)
        {
            _session = session;
        }

        public Product Handle(EditProductCommand message)
        {
            var product = new Product
            {
                Name = message.Name, 
                Price = message.Price.ToDecimal2(),
                Image = "https://res.cloudinary.com/enjoei/image/upload/c_thumb,f_auto,g_center,h_294,q_80,w_276/fmi5feex8yylxst0i5yq.jpg"
            };

            _session.SaveOrUpdate(product);

            return product;
        }
    }
}