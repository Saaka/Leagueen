using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Matches.ProviderModels;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Commands.UpdateSeasonMatches
{
    public class UpdateSeasonMatchesCommandHandler : AsyncRequestHandler<UpdateSeasonMatchesCommand>
    {
        private readonly ILogger<UpdateSeasonMatchesCommandHandler> logger;
        private readonly ISeasonsRepository seasonsRepository;
        private readonly IMatchesProvider matchesProvider;
        private readonly IMatchesEnumHelper matchesEnumHelper;

        public UpdateSeasonMatchesCommandHandler(
            ILogger<UpdateSeasonMatchesCommandHandler> logger,
            ISeasonsRepository seasonsRepository,
            IMatchesProvider matchesProvider,
            IMatchesEnumHelper matchesEnumHelper)
        {
            this.logger = logger;
            this.seasonsRepository = seasonsRepository;
            this.matchesProvider = matchesProvider;
            this.matchesEnumHelper = matchesEnumHelper;
        }

        protected override async Task Handle(UpdateSeasonMatchesCommand request, CancellationToken cancellationToken)
        {
            var season = await seasonsRepository.GetCurrentSeason(request.CompetitionCode);
            var matchesInfo = await matchesProvider.GetAllCompetitionMatches(request.CompetitionCode);

            foreach (var matchInfo in matchesInfo.Matches)
            {
                try
                {
                    TryAddMatch(season, matchInfo);
                }
                catch(DomainException ex)
                {
                    logger.LogError(ex, $"Error while updating match with externalId {matchInfo.Id}.");
                }
            }

            await seasonsRepository.SaveSeason(season);
        }

        private void TryAddMatch(Season season, MatchDto matchInfo)
        {
            var match = season.Matches.FirstOrDefault(x => x.ExternalId == matchInfo.Id);
            if (match == null)
                CreateMatch(season, matchInfo);
            else if (match.LastProviderUpdate != matchInfo.LastUpdated)
                UpdateMatch(match, matchInfo);
        }

        private void UpdateMatch(Match match, MatchDto info)
        {
            match
                .SetStatus(GetStatus(info.Status))
                .UpdateDate(info.UtcDate)
                .SetProviderUpdate(info.LastUpdated);
        }

        private void CreateMatch(Season season, MatchDto matchInfo)
        {
            var homeTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == matchInfo.HomeTeam?.Id);
            var awayTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == matchInfo.AwayTeam?.Id);
            var match = new Match(matchInfo.Id, season, homeTeam.Team, awayTeam.Team, matchInfo.UtcDate, GetStatus(matchInfo.Status), GetStage(matchInfo.Stage), matchInfo.LastUpdated);

            season.AddMatch(match);
        }

        private MatchStage GetStage(string stage)
        {
            return matchesEnumHelper.ConvertStage(stage);
        }

        private MatchStatus GetStatus(string status)
        {
            return matchesEnumHelper.ConvertStatusCode(status);
        }
    }
}
