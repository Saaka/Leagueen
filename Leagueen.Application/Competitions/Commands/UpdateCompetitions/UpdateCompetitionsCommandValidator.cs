using FluentValidation;

namespace Leagueen.Application.Competitions.Commands.UpdateCompetitionMatches
{
    public class UpdateCompetitionsCommandValidator : AbstractValidator<UpdateCompetitionsCommand>
    {
        public UpdateCompetitionsCommandValidator()
        {
            RuleFor(x => x.ProviderType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
