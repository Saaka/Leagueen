using FluentValidation;
using Leagueen.Domain.Constants;

namespace Leagueen.Application.Friends.Commands.InviteFriend
{
    public class InviteFriendCommandValidator : AbstractValidator<InviteFriendCommand>
    {
        public InviteFriendCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.AddresseeGuid)
                .NotEmpty();

            RuleFor(x => x.Guid)
                .NotEmpty()
                .MaximumLength(CommonConstants.GuidMaxLength);
        }
    }
}
