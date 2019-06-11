using FluentValidation;

namespace Leagueen.Application.Friends.Commands.AcceptFriendInvite
{
    public class AcceptFriendInviteCommandValidator : AbstractValidator<AcceptFriendInviteCommand>
    {
        public AcceptFriendInviteCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.RequestGuid)
                .NotEmpty();
        }
    }
}
