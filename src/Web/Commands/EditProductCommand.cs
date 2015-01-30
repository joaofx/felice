namespace Web.Commands
{
    using System.ComponentModel;
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
                RuleFor(x => x.Price).NotEmpty();
            }
        }
    }
}