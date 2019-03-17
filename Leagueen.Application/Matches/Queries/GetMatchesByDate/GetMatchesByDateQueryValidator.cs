using FluentValidation;

namespace Leagueen.Application.Matches.Queries.GetMatchesByDate
{
    public class GetMatchesByDateQueryValidator : AbstractValidator<GetMatchesByDateQuery>
    {
        public GetMatchesByDateQueryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
