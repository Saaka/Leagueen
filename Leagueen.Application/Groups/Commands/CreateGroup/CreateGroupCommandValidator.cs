using FluentValidation;
using Leagueen.Domain.Constants;

namespace Leagueen.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(GroupConstants.NameMinLength)
                .MaximumLength(GroupConstants.NameMaxLength);

            RuleFor(x => x.OwnerId)
                .NotEmpty();

            RuleFor(x => x.GroupGuid)
                .NotEmpty();

            RuleFor(x => x.Visibility)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.Type)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.ResultResolveMode)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.PointsForExactScore)
                .GreaterThanOrEqualTo(GroupConstants.PointsMin)
                .LessThanOrEqualTo(GroupConstants.PointsMax)
                .NotEmpty();

            RuleFor(x => x.PointsForResult)
                .GreaterThanOrEqualTo(GroupConstants.PointsMin)
                .LessThanOrEqualTo(GroupConstants.PointsMax)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(GroupConstants.DescMaxLength);
        }
    }
}
