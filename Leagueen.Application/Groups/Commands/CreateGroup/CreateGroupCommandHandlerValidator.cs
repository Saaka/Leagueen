using FluentValidation;

namespace Leagueen.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandlerValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandHandlerValidator()
        {
            RuleFor(x => x.OwnerId)
                .NotEmpty();
            RuleFor(x => x.GroupGuid)
                .NotEmpty();
        }
    }
}
