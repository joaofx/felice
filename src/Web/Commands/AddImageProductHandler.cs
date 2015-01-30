namespace Web.Commands
{
    using MediatR;
    using Models;
    using NHibernate;

    public class AddImageProductHandler : IRequestHandler<AddImageProductCommand, Unit>
    {
        private readonly ISession _session;

        public AddImageProductHandler(ISession session)
        {
            _session = session;
        }

        public Unit Handle(AddImageProductCommand message)
        {
            var imageName = message.Image.FileName;

            //message.Image.SaveAs("C:\\Temp\\" + fileName);

            var product = _session.Get<Product>(message.ProductId);

            product.Images.Add(new ProductImage
            {
                ProductId = product.Id,
                Name = imageName
            });

            _session.SaveOrUpdate(product);

            return Unit.Value;
        }
    }
}