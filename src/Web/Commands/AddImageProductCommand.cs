namespace Web.Commands
{
    using System.ComponentModel;
    using System.Web;
    using FluentValidation;
    using MediatR;

    public class AddImageProductCommand : IRequest<Unit>
    {
        public long ProductId { get; set; }

        [DisplayName("Imagem")]
        public HttpPostedFileBase Image { get; set; }

        public class AddImageProductValidator : AbstractValidator<AddImageProductCommand>
        {
            public AddImageProductValidator()
            {
                RuleFor(x => x.Image).Must(BeValidFile);
            }

            private bool BeValidFile(HttpPostedFileBase file)
            {
                //// TODO: http://stackoverflow.com/questions/26689407/my-image-validator-somehow-affects-my-httppostedfilebase-value
                return file != null;
            }
        }
    }
}