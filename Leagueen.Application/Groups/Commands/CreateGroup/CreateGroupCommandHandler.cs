using Leagueen.Application.Groups.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : AsyncRequestHandler<CreateGroupCommand>
    {
        private readonly ILogger logger;
        private readonly IGroupAggregateRepository groupAggregateRepository;
        private readonly IDateTime dateTime;

        public CreateGroupCommandHandler(
            ILogger<CreateGroupCommandHandler> logger,
            IGroupAggregateRepository groupAggregateRepository,
            IDateTime dateTime)
        {
            this.logger = logger;
            this.groupAggregateRepository = groupAggregateRepository;
            this.dateTime = dateTime;
        }

        protected override async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"CreateGroupCommandHandler: {request.GroupGuid}");

            var group = new Group(request.GroupGuid, request.OwnerId, request.Name, request.Description);
            var groupSettings = new GroupSettings(request.PointsForExactScore, request.PointsForResult, request.Type, request.Visibility, request.ResultResolveMode);

            if (groupSettings.Type == Domain.Enums.GroupType.Competition)
                groupSettings.SetCompetition(request.CompetitionId.Value, request.SeasonId.Value);

            group
                .AddSettings(groupSettings)
                .AddMember(new GroupMember(request.OwnerId))
                .MarkUpdate(dateTime.GetUtcNow());

            await groupAggregateRepository.SaveGroup(group);
        }
    }
}
