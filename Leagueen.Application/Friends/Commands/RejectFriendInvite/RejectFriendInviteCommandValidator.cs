using FluentValidation;

namespace Leagueen.Application.Friends.Commands.RejectFriendInvite
{
    public class RejectFriendInviteCommandValidator : AbstractValidator<RejectFriendInviteCommand>
    {
        public RejectFriendInviteCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.RequestGuid)
                .NotEmpty();                
        }
    }
}
