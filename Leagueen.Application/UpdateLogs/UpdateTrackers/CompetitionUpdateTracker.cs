using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Matches.Commands;
using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs.UpdateTrackers
{
    public class CompetitionUpdateTracker : IUpdateTracker<UpdateAllSeasonMatchesCommand, Unit>
    {
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly IUpdateLogsRepository updateLogsRepository;
        private readonly IDateTime dateTime;

        public CompetitionUpdateTracker(
            ICompetitionsRepository competitionsRepository,
            IUpdateLogsRepository updateLogsRepository,
            IDateTime dateTime)
        {
            this.competitionsRepository = competitionsRepository;
            this.updateLogsRepository = updateLogsRepository;
            this.dateTime = dateTime;
        }
        public Task<bool> ShouldPerformUpdate(UpdateAllSeasonMatchesCommand request)
        {
            return Task.FromResult(true);
        }

        public async Task TrackUpdate(UpdateAllSeasonMatchesCommand request, bool isExecuted)
        {
            var provider = await competitionsRepository.GetProviderTypeForCompetition(request.CompetitionType);
            await updateLogsRepository
                .SaveUpdateLog(new UpdateLog(UpdateLogType.Competition, provider, request.CompetitionType, dateTime.GetUtcNow()));
        }
    }
}
