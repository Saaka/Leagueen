using Leagueen.Application.Users.Models;
using MediatR;
using System;

namespace Leagueen.Application.Users.Queries
{
    public class GetUserByGuidQuery : IRequest<GetUserByGuidQueryResult>
    {
        public GetUserByGuidQuery(Guid guid)
        {
            UserGuid = guid;
        }

        public Guid UserGuid { get; private set; }
    }
}
