using Leagueen.Application.Competitions.Commands;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Matches;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly IMediator mediator;

        public UpdateAllSeasonMatchesCommandHandler(
            ILogger<UpdateAllSeasonMatchesCommandHandler> logger,
            ISeasonsRepository seasonsRepository,
            IMatchesProvider matchesProvider,
            IMatchFactory matchFactory,
            IMatchUpdater matchUpdater,
            IMediator mediator)
        {
            this.logger = logger;
            this.seasonsRepository = seasonsRepository;
            this.matchesProvider = matchesProvider;
            this.matchFactory = matchFactory;
            this.matchUpdater = matchUpdater;
            this.mediator = mediator;
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

            if (NewSeasonStarted(season, matchesInfo.Matches.First().SeasonId))
            {
                logger.LogInformation($"{nameof(UpdateAllSeasonMatchesCommandHandler)}: New season started. Initializing current season");
                await mediator.Send(new UpdateCompetitionCurrentSeasonCommand { CompetitionCode = request.CompetitionType.ToString(), UpdateMatches = false });
                season = await seasonsRepository.GetCurrentSeason(request.CompetitionType.ToString());
            }

            int count = 0;
            foreach (var matchInfo in matchesInfo.Matches)
            {
                try
                {
                    if (AddOrCreateMatch(season, matchInfo))
                        count++;
                }
                catch (DomainException ex)
                {
                    logger.LogError(ex, $"Error while updating match with externalId {matchInfo.Id}.");
                }
            }

            await seasonsRepository.SaveSeason(season);
            logger.LogInformation($"{nameof(UpdateAllSeasonMatchesCommandHandler)}: Updated {count} matches");
        }

        private bool NewSeasonStarted(Season season, int seasonId)
        {
            return season.ExternalId != seasonId;
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
