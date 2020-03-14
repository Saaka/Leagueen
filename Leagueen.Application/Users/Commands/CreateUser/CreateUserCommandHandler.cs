using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
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
            var user = new User(request.UserGuid, request.Email, request.DisplayName, request.ImageUrl);

            await _userAggregateRepository.SaveUser(user);
        }
    }
}
