using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class UpdateCompetitionsCommand : IRequest
    {
        public DataProviderType ProviderType { get; set; }
    }
}
