using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Providers.IdentityProvider
{
    public interface IIdentityProvider
    {
        Task<UserDto> AuthUserByCredentials(string email, string password);
    }
}
