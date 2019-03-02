namespace Leagueen.Application.Security
{
    public interface IJwtTokenFactory
    {
        string Create(string moniker, bool isAdmin);
    }
}
