using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.UpdateLogs
{
    public interface ITrackable : IRequest
    {
        DataProviderType ProviderType { get; }
    }
}
