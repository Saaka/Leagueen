using FluentValidation;

namespace Leagueen.Application.Groups.Queries.GetUserGroups
{
    public class GetUserGroupsQueryValidator : AbstractValidator<GetUserGroupsQuery>
    {
        public GetUserGroupsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
