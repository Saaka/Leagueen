using FluentValidation;
using Leagueen.Domain.Constants;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithGoogle
{
    public class AuthenticateUserWithGoogleCommandValidator : AbstractValidator<AuthenticateUserWithGoogleCommand>
    {
        public AuthenticateUserWithGoogleCommandValidator()
        {
            RuleFor(x => x.DisplayName)
                .Length(UserConstants.MinDisplayNameLength, UserConstants.MaxDisplayNameLength)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(UserConstants.MinEmailLength, UserConstants.MaxPasswordLength);
            RuleFor(x => x.ImageUrl)
                .MaximumLength(UserConstants.MaxImageUrlLength);
            RuleFor(x => x.GoogleId)
                .NotEmpty()
                .MaximumLength(UserConstants.MaxGoogleIdLength);
        }
    }
}
