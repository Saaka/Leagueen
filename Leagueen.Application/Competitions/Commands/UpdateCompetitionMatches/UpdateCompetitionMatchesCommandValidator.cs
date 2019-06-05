using FluentValidation;

namespace Leagueen.Application.Competitions.Commands.UpdateCompetitionMatches
{
    public class UpdateCompetitionMatchesCommandValidator : AbstractValidator<UpdateCompetitionMatchesCommand>
    {
        public UpdateCompetitionMatchesCommandValidator()
        {
            RuleFor(x => x.ProviderType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
