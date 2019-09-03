﻿using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Matches;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Commands.UpdateAllSeasonMatches
{
    public class UpdateAllSeasonMatchesCommandHandler : AsyncRequestHandler<UpdateAllSeasonMatchesCommand>
    {
        private readonly ILogger<UpdateAllSeasonMatchesCommandHandler> logger;
        private readonly ISeasonsRepository seasonsRepository;
        private readonly IMatchesProvider matchesProvider;
        private readonly IMatchFactory matchFactory;
        private readonly IMatchUpdater matchUpdater;

        public UpdateAllSeasonMatchesCommandHandler(
            ILogger<UpdateAllSeasonMatchesCommandHandler> logger,
            ISeasonsRepository seasonsRepository,
            IMatchesProvider matchesProvider,
            IMatchFactory matchFactory,
            IMatchUpdater matchUpdater)
        {
            this.logger = logger;
            this.seasonsRepository = seasonsRepository;
            this.matchesProvider = matchesProvider;
            this.matchFactory = matchFactory;
            this.matchUpdater = matchUpdater;
        }

        protected override async Task Handle(UpdateAllSeasonMatchesCommand request, CancellationToken cancellationToken)
        {
            var season = await seasonsRepository.GetCurrentSeason(request.CompetitionType.ToString());
            if (season == null)
                throw new DomainException(ExceptionCode.ActiveSeasonNotFoundForCompetition, $"CompetitionCode: {request.CompetitionType.ToString()}");
            var matchesInfo = await matchesProvider.GetAllCompetitionMatches(request.CompetitionType);
            if (!matchesInfo.Matches.Any())
            {
                logger.LogInformation($"{nameof(UpdateAllSeasonMatchesCommandHandler)}: Season has no matches, update stopped");
                return;
            }

            var matchesSeasonId = matchesInfo.Matches.First().SeasonId;
            if (season.ExternalId != matchesSeasonId)
            {
                logger.LogInformation($"{nameof(UpdateAllSeasonMatchesCommandHandler)}: New season started. Please initiate season with external id: {matchesSeasonId}");
                return;
            }

            int updateCount = 0;
            foreach (var matchInfo in matchesInfo.Matches)
            {
                try
                {
                    if (AddOrCreateMatch(season, matchInfo))
                        updateCount++;
                }
                catch (DomainException ex)
                {
                    logger.LogError(ex, $"Error while updating match with externalId {matchInfo.Id}.");
                }
            }

            int deleteCount = 0;
            foreach (var seasonMatch in season.Matches)
            {
                try
                {
                    if (RemoveIfNotExists(seasonMatch, season, matchesInfo))
                        deleteCount++;
                }
                catch (DomainException ex)
                {
                    logger.LogError(ex, $"Error while checking season match with id {seasonMatch.MatchId}");
                }
            }

            await seasonsRepository.SaveSeason(season);
            logger.LogInformation($"{nameof(UpdateAllSeasonMatchesCommandHandler)}: Updated {updateCount} matches");
        }

        private bool RemoveIfNotExists(Match seasonMatch, Season season, MatchListDto matchList)
        {
            var matchDto = matchList.Matches.FirstOrDefault(x => x.Id == seasonMatch.ExternalId);
            if(matchDto == null)
            {
                season.RemoveMatch(seasonMatch);
                return true;
            }

            return false;
        }

        private bool AddOrCreateMatch(Season season, MatchDto matchInfo)
        {
            var match = season.Matches.FirstOrDefault(x => x.ExternalId == matchInfo.Id);
            if (match == null)
            {
                match = matchFactory.CreateMatch(season, matchInfo);
                if (match != null)
                {
                    season.AddMatch(match);
                    return true;
                }

                return false;
            }
            else
                return matchUpdater.UpdateMatch(match, matchInfo);
        }

    }
}
