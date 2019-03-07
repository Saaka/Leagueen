using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task CreateAsync(CreateUserDto userData);
        Task CreateAsync(CreateGoogleUserDto userData);
        Task<bool> GoogleUserExists(string email, string externalUserId);
        Task<bool> IsEmailRegistered(string email);
        Task<UserDto> MergeUserWithGoogle(string email, string externalUserId, string imageUrl);
        Task<UserDto> UpdateExistingGoogleUser(string email, string imageUrl);
        Task<UserDto> GetUserByCredentials(string email, string password);
    }
}
