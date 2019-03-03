using FluentValidation;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithCredentials
{
    public class AuthenticateUserWithCredentialsCommandValidator : AbstractValidator<AuthenticateUserWithCredentialsCommand>
    {
        public AuthenticateUserWithCredentialsCommandValidator()
        {
        }
    }
}
