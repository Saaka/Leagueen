using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class UserAggregateRepository : IUserAggregateRepository
    {
        public async Task SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
