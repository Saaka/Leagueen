using FluentValidation;

namespace Leagueen.Application.Matches.Commands.UpdateSeasonMatches
{
    public class UpdateSeasonMatchesCommandValidator : AbstractValidator<UpdateSeasonMatchesCommand>
    {
        public UpdateSeasonMatchesCommandValidator()
        {
            RuleFor(x => x.CompetitionCode)
                .NotEmpty();
        }
    }
}
