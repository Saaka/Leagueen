using FluentValidation;
using Leagueen.Domain.Enums;

namespace Leagueen.Application.Matches.Commands.UpdateAllSeasonMatches
{
    public class UpdateAllSeasonMatchesCommandValidator : AbstractValidator<UpdateAllSeasonMatchesCommand>
    {
        public UpdateAllSeasonMatchesCommandValidator()
        {
            RuleFor(x => x.CompetitionType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
