using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class UpdateCompetitionTeamsInCurrentSeasonCommand : IRequest
    {
        public string CompetitionCode { get; set; }
    }
}
