using Leagueen.Application.Users.Models;

namespace Leagueen.Application.Security
{
    public interface IJwtTokenFactory
    {
        string Create(UserDto user);
    }
}
