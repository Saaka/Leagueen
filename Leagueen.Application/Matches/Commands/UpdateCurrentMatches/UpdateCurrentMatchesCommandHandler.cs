using Leagueen.Application.DataProviders;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Commands.UpdateCurrentMatches
{
    public class UpdateCurrentMatchesCommandHandler : AsyncRequestHandler<UpdateCurrentMatchesCommand>
    {
        private readonly ILogger logger;
        private readonly IDateTime dateTime;
        private readonly IMatchesRepository matchesRepository;
        private readonly IMatchesProvider matchesProvider;
        private readonly IMatchUpdater matchUpdater;

        public UpdateCurrentMatchesCommandHandler(
            ILogger<UpdateCurrentMatchesCommandHandler> logger,
            IDateTime dateTime,
            IMatchesRepository matchesRepository,
            IMatchesProvider matchesProvider,
            IMatchUpdater matchUpdater)
        {
            this.logger = logger;
            this.dateTime = dateTime;
            this.matchesRepository = matchesRepository;
            this.matchesProvider = matchesProvider;
            this.matchUpdater = matchUpdater;
        }

        protected override async Task Handle(UpdateCurrentMatchesCommand request, CancellationToken cancellationToken)
        {
            var date = dateTime.GetUtcNow().Date;
            var matches = await matchesRepository.GetAllMatchesByDate(date);
            var matchesInfo = await matchesProvider.GetTodaysMatches();
            var toSave = new List<Match>();
            foreach(var match in matches)
            {
                var info = matchesInfo.Matches.FirstOrDefault(x => x.Id == match.ExternalId);
                if (info == null) continue;

                if (matchUpdater.UpdateMatch(match, info))
                    toSave.Add(match);
            }

            if(matches.Any())
            {
                await matchesRepository.SaveMatches(toSave);
                logger.LogInformation($"{nameof(UpdateCurrentMatchesCommandHandler)}: Updated {matches.Count()} matches");
            }
        }
    }
}
