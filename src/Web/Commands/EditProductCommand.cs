namespace Web.Commands
{
    using System.ComponentModel;
    using System.Web;
    using FluentValidation;
    using MediatR;
    using Models;

    public class EditProductCommand : IRequest<Product>
    {
        public long Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Preço")]
        public string Price { get; set; }

        public class EditProductValidator : AbstractValidator<EditProductCommand>
        {
            public EditProductValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                //RuleFor(x => x.MainImage).Must(BeValidFile);
            }

            //private bool BeValidFile(HttpPostedFileBase file)
            //{
            //    //// TODO: http://stackoverflow.com/questions/26689407/my-image-validator-somehow-affects-my-httppostedfilebase-value
            //    return file != null;
            //}
        }
    }
}