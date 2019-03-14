using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateAllSeasonMatchesCommand : IRequest
    {
        public string CompetitionCode { get; set; }
    }
}
