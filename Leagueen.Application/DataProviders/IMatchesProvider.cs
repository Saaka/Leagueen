using Leagueen.Application.DataProviders.Matches;
using System.Threading.Tasks;

namespace Leagueen.Application.DataProviders
{
    public interface IMatchesProvider
    {
        Task<MatchListDto> GetTodaysMatches();
        Task<MatchListDto> GetAllCompetitionMatches(string competitionCode);
    }
}
