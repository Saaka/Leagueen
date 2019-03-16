using Leagueen.Application.Matches.Commands;
using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using MediatR;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs.UpdateTrackers
{
    public class CurrentMatchesUpdateTracker : IUpdateTracker<UpdateCurrentMatchesCommand, Unit>
    {
        private readonly IUpdateLogsRepository updateLogsRepository;
        private readonly IDateTime dateTime;

        public CurrentMatchesUpdateTracker(
            IUpdateLogsRepository updateLogsRepository,
            IDateTime dateTime)
        {
            this.updateLogsRepository = updateLogsRepository;
            this.dateTime = dateTime;
        }

        public async Task TrackUpdate(UpdateCurrentMatchesCommand request)
        {
            await updateLogsRepository
                .SaveUpdateLog(new UpdateLog(UpdateLogType.CurrentMatch, request.ProviderType, dateTime.GetUtcNow()));
        }

        public async Task<bool> ShouldPerformUpdate(UpdateCurrentMatchesCommand request)
        {
            var lastUpdate = await updateLogsRepository.GetLastUpdateLog(UpdateLogType.CurrentMatch, request.ProviderType);
            return lastUpdate == null || lastUpdate.Date.Hour != dateTime.GetUtcNow().Hour;
        }
    }
}
