using Leagueen.Application.UpdateLogs;
using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class UpdateCompetitionCurrentSeasonCommand : IRequest, ITrackable
    {
        public CompetitionType CompetitionType { get; set; }
    }
}
