using System.Threading.Tasks;

namespace Leagueen.Application.Security.Google
{
    public interface IFacebookApiClient
    {
        Task<TokenInfo> GetTokenInfoAsync(string token);
    }
}
