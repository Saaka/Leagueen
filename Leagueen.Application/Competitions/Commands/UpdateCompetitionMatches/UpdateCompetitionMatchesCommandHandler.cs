using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Matches.Commands;
using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Common;
using MediatR;

namespace Leagueen.Application.Competitions.Commands.UpdateCompetitionMatches
{
    public class UpdateCompetitionMatchesCommandHandler : AsyncRequestHandler<UpdateCompetitionMatchesCommand>
    {
        private readonly IMediator mediator;
        private readonly IUpdateLogsRepository updateLogsRepository;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly IDateTime dateTime;

        public UpdateCompetitionMatchesCommandHandler(
            IMediator mediator,
            IUpdateLogsRepository updateLogsRepository,
            ICompetitionsRepository competitionsRepository,
            IDateTime dateTime)
        {
            this.mediator = mediator;
            this.updateLogsRepository = updateLogsRepository;
            this.competitionsRepository = competitionsRepository;
            this.dateTime = dateTime;
        }

        protected override async Task Handle(UpdateCompetitionMatchesCommand request, CancellationToken cancellationToken)
        {
            var updates = await updateLogsRepository.GetCompetitionUpdatesForProvider(request.ProviderType, dateTime.GetUtcNow());
            var competitionTypes = await competitionsRepository.GetAllActiveCompetitionTypesForProvider(request.ProviderType);
            foreach (var compType in competitionTypes)
            {
                if (updates.Any(x => x.CompetitionType.Value == compType)) continue;

                var command = new UpdateAllSeasonMatchesCommand { CompetitionType = compType };
                await mediator.Send(command);
                return;
            }
        }
    }
}
