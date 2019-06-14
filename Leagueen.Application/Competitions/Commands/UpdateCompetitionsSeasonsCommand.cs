using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Competitions.Commands
{
    public class UpdateCompetitionsSeasonsCommand : IRequest
    {
        public DataProviderType ProviderType { get; set; }
    }
}
