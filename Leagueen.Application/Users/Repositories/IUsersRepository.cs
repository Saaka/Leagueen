using Leagueen.Application.Users.Models;
using System;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> GetUserByGuid(Guid guid);
        Task<int?> GetUserIdByGuid(Guid guid);
    }
}
