using Leagueen.Application.UpdateLogs;
using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateAllSeasonMatchesCommand : IRequest//, ITrackable Update this command.
    {
        public string CompetitionCode { get; set; }
    }
}
