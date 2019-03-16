using FluentValidation;

namespace Leagueen.Application.Matches.Commands.UpdateCurrentMatches
{
    public class UpdateCurrentMatchesCommandValidator : AbstractValidator<UpdateCurrentMatchesCommand>
    {
        public UpdateCurrentMatchesCommandValidator()
        {
            RuleFor(x => x.ProviderType)
                .IsInEnum()
                .NotEmpty();
        }
    }
}
