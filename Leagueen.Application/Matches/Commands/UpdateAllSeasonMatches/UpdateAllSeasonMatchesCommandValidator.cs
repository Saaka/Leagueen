using FluentValidation;

namespace Leagueen.Application.Matches.Commands.UpdateAllSeasonMatches
{
    public class UpdateAllSeasonMatchesCommandValidator : AbstractValidator<UpdateAllSeasonMatchesCommand>
    {
        public UpdateAllSeasonMatchesCommandValidator()
        {
            RuleFor(x => x.CompetitionCode)
                .NotEmpty();
        }
    }
}
