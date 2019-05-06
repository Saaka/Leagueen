using FluentValidation;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithFacebook
{
    public class AuthenticateUserWithFacebookCommandValidator : AbstractValidator<AuthenticateUserWithFacebookCommand>
    {
        public AuthenticateUserWithFacebookCommandValidator()
        {
            RuleFor(x => x.FacebookToken)
                .NotEmpty();
        }
    }
}
