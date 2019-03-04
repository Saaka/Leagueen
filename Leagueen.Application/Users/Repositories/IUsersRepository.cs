using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task CreateAsync(CreateUserDto userData);
        Task CreateAsync(CreateGoogleUserDto userData);
    }
}
