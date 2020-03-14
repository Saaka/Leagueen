using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Queries.GetUserByGuid
{
    public class GetUserByGuidQueryHandler : IRequestHandler<GetUserByGuidQuery, GetUserByGuidQueryResult>
    {
        private IUsersRepository _usersRepository;

        public GetUserByGuidQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<GetUserByGuidQueryResult> Handle(GetUserByGuidQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetUserByGuid(request.UserGuid);

            return new GetUserByGuidQueryResult
            {
                UserExists = user != null,
                User = user
            };
        }
    }
}
