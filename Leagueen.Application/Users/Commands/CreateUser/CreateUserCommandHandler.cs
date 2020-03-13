using Leagueen.Application.Users.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly ILogger _logger;
        private readonly IUserAggregateRepository _userAggregateRepository;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
            IUserAggregateRepository userAggregateRepository)
        {
            _logger = logger;
            _userAggregateRepository = userAggregateRepository;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
