using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : AsyncRequestHandler<CreateGroupCommand>
    {
        private readonly ILogger logger;

        public CreateGroupCommandHandler(
            ILogger<CreateGroupCommandHandler> logger)
        {
            this.logger = logger;
        }

        protected override async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"CreateGroupCommandHandler: {request.GroupGuid}");
        }
    }
}
