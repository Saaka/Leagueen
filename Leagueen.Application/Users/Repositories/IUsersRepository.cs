using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> GetUserByGuid(string guid);
        Task<int?> GetUserIdByGuid(string guid);
    }
}
