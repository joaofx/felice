namespace Web.Commands
{
    using System.Web;
    using FluentValidation;
    using MediatR;
    using Models;

    public class EditProductCommand : IRequest<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public class EditProductValidator : AbstractValidator<EditProductCommand>
        {
            public EditProductValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Image).Must(NotEmpty);
            }

            private bool NotEmpty(HttpPostedFileBase file)
            {
                return file != null;
            }

            //// http://stackoverflow.com/questions/26689407/my-image-validator-somehow-affects-my-httppostedfilebase-value
        }
    }
}