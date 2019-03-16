using MediatR;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs
{
    
    public interface IUpdateTracker<T, R>
        //Can't be more restrictive because MS DI does not support constrained open generics
        //In .NET Core this can be changed to just ITrackable
        where T : IRequest<R>
    {
        Task TrackUpdate(T request, bool isExecuted);
        Task<bool> ShouldPerformUpdate(T request);
    }
}
