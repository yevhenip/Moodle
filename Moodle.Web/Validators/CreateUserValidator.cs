using FluentValidation;
using Moodle.Web.Models;

namespace Moodle.Web.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(cu => cu.FullName).MaximumLength(55)
                .WithMessage("Maximum length is 55");
            RuleFor(cu => cu.FullName).MinimumLength(5)
                .WithMessage("Minimum length is 5");
            
            RuleFor(cu => cu.UserName).MaximumLength(55)
                .WithMessage("Maximum length is 55");
            RuleFor(cu => cu.UserName).MinimumLength(5)
                .WithMessage("Minimum length is 5");

            RuleFor(cu => cu.Email).NotEmpty()
                .NotEmpty().WithMessage("Email required");
            RuleFor(cu => cu.Email).EmailAddress()
                .WithMessage("Enter correct email");

            RuleFor(cu => cu.Phone).NotEmpty()
                .NotEmpty().WithMessage("Phone required");
            
            RuleFor(cu => cu.BirthDate).NotEmpty()
                .NotEmpty().WithMessage("Birth Date required");
            
            RuleFor(cu => cu.Password).NotEmpty()
                .NotEmpty().WithMessage("Password required");
           
            RuleFor(cu => cu.Password).NotEmpty()
                .NotEmpty().WithMessage("Confirmation required");
            RuleFor(cu => cu).Custom((cu, context) =>
            {
                if (cu.Password != cu.PasswordConfirmed)
                {
                    context.AddFailure(nameof(cu.Password), "Passwords should match");
                }
            });
            
            RuleFor(cu => cu.UserType).NotEmpty()
                .NotEmpty().WithMessage("User Type required");
        }
    }
}