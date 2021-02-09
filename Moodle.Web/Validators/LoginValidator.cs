using FluentValidation;
using Moodle.Web.Models;

namespace Moodle.Web.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(lm => lm.UserName).NotEmpty().NotNull()
                .WithMessage("Username required");
            RuleFor(lm => lm.UserName).MaximumLength(20)
                .WithMessage("Username should be less than 20 characters");
            
            RuleFor(lm => lm.Password).NotEmpty().NotNull()
                .WithMessage("Password required");
        }
    }
}