using FluentValidation;
using FluentValidation.Results;

namespace Web.Commands
{
    public class EditProductValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty(); 
        }

        public override ValidationResult Validate(EditProductCommand instance)
        {
            return base.Validate(instance);
        }
    }
}