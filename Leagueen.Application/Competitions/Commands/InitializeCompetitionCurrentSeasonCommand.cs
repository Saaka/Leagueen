using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class InitializeCompetitionCurrentSeasonCommand : IRequest
    {
        public string CompetitionCode { get; set; }
        public bool InitializeMatches { get; set; }
    }
}
