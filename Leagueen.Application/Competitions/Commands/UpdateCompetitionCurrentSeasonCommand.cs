using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class UpdateCompetitionCurrentSeasonCommand : IRequest
    {
        public string CompetitionCode { get; set; }
    }
}
