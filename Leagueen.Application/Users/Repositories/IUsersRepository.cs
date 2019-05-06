using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<UserDto> CreateAsync(CreateUserDto userData);
        Task<UserDto> CreateAsync(CreateGoogleUserDto userData);
        Task<UserDto> CreateAsync(CreateFacebookUserDto userData);
        Task<bool> GoogleUserExists(string email, string externalUserId);
        Task<bool> FacebookUserExists(string email, string externalUserId);
        Task<bool> IsEmailRegistered(string email);
        Task<UserDto> MergeUserWithGoogle(string email, string externalUserId, string imageUrl);
        Task<UserDto> MergeUserWithFacebook(string email, string externalUserId, string imageUrl);
        Task<UserDto> UpdateExistingGoogleUser(string email, string imageUrl);
        Task<UserDto> UpdateExistingFacebookUser(string email, string imageUrl);
        Task<UserDto> GetUserByCredentials(string email, string password);
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> GetUserByMoniker(string moniker);
        Task<int?> GetUserIdByMoniker(string moniker);
        Task<bool> IsDisplayNameInUse(int userId, string displayName);
        Task<UserDto> UpdateUserDisplayName(int userId, string displayName);
    }
}
