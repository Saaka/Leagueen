using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Matches.ProviderModels;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
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
            if (season == null)
                throw new DomainException(ExceptionCode.AtiveSeasonNotFoundForCompetition, $"CompetitionCode:{request.CompetitionCode}");
            var matchesInfo = await matchesProvider.GetAllCompetitionMatches(request.CompetitionCode);

            foreach (var matchInfo in matchesInfo.Matches)
            {
                try
                {
                    TryAddMatch(season, matchInfo);
                }
                catch (DomainException ex)
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
                match = CreateMatch(season, matchInfo);
            else if (match.LastProviderUpdate != matchInfo.LastUpdated)
                UpdateMatch(match, matchInfo);
        }

        private void UpdateMatch(Match match, MatchDto info)
        {
            if (!string.IsNullOrEmpty(info.Score.Winner))
            {
                if (match.MatchScore != null)
                    UpdateScore(match.MatchScore, info.Score);
                else
                    CreateScore(match, info.Score);
            }
            match
            .SetStatus(GetStatus(info.Status))
            .UpdateDate(info.UtcDate)
            .SetProviderUpdate(info.LastUpdated);
        }

        private void UpdateScore(MatchScore matchScore, MatchScoreDto info)
        {
            matchScore.UpdateScore(GetResult(info.Winner), GetDuration(info.Duration),
                info.FullTime?.HomeTeam, info.FullTime?.AwayTeam, info.HalfTime?.HomeTeam, info.HalfTime.AwayTeam,
                info.ExtraTime?.HomeTeam, info.ExtraTime?.AwayTeam, info.Penalties?.HomeTeam, info.Penalties?.AwayTeam);
        }

        private Match CreateMatch(Season season, MatchDto info)
        {
            var homeTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == info.HomeTeam?.Id);
            var awayTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == info.AwayTeam?.Id);
            var match = new Match(info.Id, season, homeTeam.Team, awayTeam.Team,
                info.UtcDate, GetStatus(info.Status), GetStage(info.Stage), info.LastUpdated);
            
            if (!string.IsNullOrEmpty(info.Score.Winner))
                CreateScore(match, info.Score);

            return match;
        }

        private MatchScore CreateScore(Match match, MatchScoreDto info)
        {
            return new MatchScore(match, GetResult(info.Winner), GetDuration(info.Duration),
                info.FullTime?.HomeTeam, info.FullTime?.AwayTeam, info.HalfTime?.HomeTeam, info.HalfTime.AwayTeam,
                info.ExtraTime?.HomeTeam, info.ExtraTime?.AwayTeam, info.Penalties?.HomeTeam, info.Penalties?.AwayTeam);
        }

        private MatchDuration GetDuration(string duration)
        {
            return matchesEnumHelper.ConvertDuration(duration);
        }

        private MatchResult GetResult(string winner)
        {
            return matchesEnumHelper.ConvertResult(winner);
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
