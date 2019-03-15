using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Matches.Commands
{
    public class UpdateCurrentMatchesCommand : IRequest
    {
        public DataProviderType ProviderType { get; set; }
    }
}
