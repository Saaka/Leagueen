using Leagueen.Application.Matches.ProviderModels;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches
{
    public interface IMatchesProvider
    {
        Task<MatchListDto> GetTodaysMatches();
        Task<MatchListDto> GetAllCompetitionMatches(int competitionId);
    }
}
