using Leagueen.Application.Matches.Commands;
using Leagueen.Application.Matches.Repositories;
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
        private readonly IMatchesRepository matchesRepository;
        private readonly IDateTime dateTime;
        private readonly IGuid guid;

        public CurrentMatchesUpdateTracker(
            IUpdateLogsRepository updateLogsRepository,
            IMatchesRepository matchesRepository,
            IDateTime dateTime,
            IGuid guid)
        {
            this.updateLogsRepository = updateLogsRepository;
            this.matchesRepository = matchesRepository;
            this.dateTime = dateTime;
            this.guid = guid;
        }

        public async Task TrackUpdate(UpdateCurrentMatchesCommand request, bool isExecuted)
        {
            await updateLogsRepository
                .SaveUpdateLog(new UpdateLog(guid.GetGuid(), UpdateLogType.CurrentMatch, request.ProviderType, dateTime.GetUtcNow(), isExecuted));
        }

        public async Task<bool> ShouldPerformUpdate(UpdateCurrentMatchesCommand request)
        {
            var lastUpdate = await updateLogsRepository.GetLastUpdateLog(UpdateLogType.CurrentMatch, request.ProviderType);
            if (lastUpdate == null)
                return true;

            var areMatchesInPlay = await matchesRepository.AreMatchesInPlay(dateTime.GetUtcNow());

            return areMatchesInPlay || lastUpdate.Date.Hour != dateTime.GetUtcNow().Hour;
        }
    }
}
