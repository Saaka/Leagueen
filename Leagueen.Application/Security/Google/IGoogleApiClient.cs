using System.Threading.Tasks;

namespace Leagueen.Application.Security.Google
{
    public interface IGoogleApiClient
    {
        Task<TokenInfo> GetTokenInfoAsync(string token);
    }
}
