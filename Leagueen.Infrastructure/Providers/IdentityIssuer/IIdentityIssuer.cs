using Leagueen.Application.Users.Models;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Providers.IdentityIssuer
{
    public interface IIdentityIssuer
    {
        Task<UserDto> AuthUserByCredentials(string email, string password);
    }
}
