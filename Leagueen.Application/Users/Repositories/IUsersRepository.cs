using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<int> CreateAsync(CreateUserDto userData);
    }
}
