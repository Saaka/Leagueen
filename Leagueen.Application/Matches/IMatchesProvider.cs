using Leagueen.Application.Matches.Models;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches
{
    public interface IMatchesProvider
    {
        Task<MatchListDto> GetTodaysMatches();
    }
}
