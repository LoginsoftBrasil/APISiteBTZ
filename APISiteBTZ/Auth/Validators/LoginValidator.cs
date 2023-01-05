using APISiteBTZ.Auth.Dtos;
using FluentValidation;

namespace APISiteBTZ.Auth.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().OverridePropertyName("name");
            RuleFor(x => x.Password).NotEmpty().OverridePropertyName("password");
        }
    }
}
