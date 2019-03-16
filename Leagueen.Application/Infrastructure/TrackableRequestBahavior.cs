using Leagueen.Application.UpdateLogs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure
{
    public class TrackableRequestBahavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        private readonly IUpdateTrackerFactory updateTrackerFactory;

        public TrackableRequestBahavior(
            IUpdateTrackerFactory updateTrackerFactory)
        {
            this.updateTrackerFactory = updateTrackerFactory;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!(request is ITrackable))
                return await next();
            var dataUpdateTracker = updateTrackerFactory.Create<TRequest, TResponse>();
            if (dataUpdateTracker == null)
                return await next();

            var performUpdate = await dataUpdateTracker.ShouldPerformUpdate(request);
            if (!performUpdate)
            {
                await dataUpdateTracker.TrackUpdate(request, false);
                return default(TResponse);
            }

            var response = await next();
            await dataUpdateTracker.TrackUpdate(request, true);

            return response;
        }
    }
}
