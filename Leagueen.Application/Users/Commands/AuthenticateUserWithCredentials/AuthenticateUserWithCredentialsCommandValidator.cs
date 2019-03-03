using FluentValidation;
using Leagueen.Domain.Constants;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithCredentials
{
    public class AuthenticateUserWithCredentialsCommandValidator : AbstractValidator<AuthenticateUserWithCredentialsCommand>
    {
        public AuthenticateUserWithCredentialsCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .Length(UserConstants.MinEmailLength, UserConstants.MaxPasswordLength);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(UserConstants.MinPasswordLength, UserConstants.MaxPasswordLength);
        }
    }
}
