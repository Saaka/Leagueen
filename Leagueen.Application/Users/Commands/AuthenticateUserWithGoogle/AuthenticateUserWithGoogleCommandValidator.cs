using FluentValidation;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithGoogle
{
    public class AuthenticateUserWithGoogleCommandValidator : AbstractValidator<AuthenticateUserWithGoogleCommand>
    {
        public AuthenticateUserWithGoogleCommandValidator()
        {
            RuleFor(x => x.GoogleToken)
                .NotEmpty();
        }
    }
}
