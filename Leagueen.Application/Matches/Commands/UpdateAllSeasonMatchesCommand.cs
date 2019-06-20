using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateAllSeasonMatchesCommand : IRequest
    {
        public UpdateAllSeasonMatchesCommand() { }

        public CompetitionType CompetitionType { get; set; }
    }
}
