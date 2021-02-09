using FluentValidation;
using Moodle.Web.Models;

namespace Moodle.Web.Validators
{
    public class CreateGroupValidator : AbstractValidator<ModelGroup>
    {
        public CreateGroupValidator()
        {
            RuleFor(g => g.Name).NotNull().NotEmpty()
                .WithMessage("Name is required");
            
            RuleFor(g => g.Class).NotNull().NotEmpty()
                .WithMessage("Class is required");
            RuleFor(g => g.Class).GreaterThan(0)
                .WithMessage("Class must me grater than 0");
        }
    }
}