using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateSeasonMatchesCommand : IRequest
    {
        public string CompetitionCode { get; set; }
    }
}
