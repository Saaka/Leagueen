using FluentValidation;
using Leagueen.Domain.Constants;

namespace Leagueen.Application.Users.Commands
{
    public class CreateUserWithCredentialsCommandValidator : AbstractValidator<CreateUserWithCredentialsCommand>
    {
        public CreateUserWithCredentialsCommandValidator()
        {
            RuleFor(x => x.DisplayName)
                .Length(UserConstants.MinDisplayNameLength, UserConstants.MaxDisplayNameLength)
                .NotEmpty();
            RuleFor(x => x.Password)
                .Length(UserConstants.MinPasswordLength, UserConstants.MaxPasswordLength)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
