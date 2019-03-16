using Leagueen.Application.UpdateLogs;
using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateCurrentMatchesCommand : IRequest, ITrackable
    {
        public DataProviderType ProviderType { get; set; }
    }
}
