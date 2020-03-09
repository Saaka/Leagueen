using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using System;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Users
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<UserDto> GetUserByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetUserIdByGuid(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
