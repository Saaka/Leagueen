using Leagueen.Application.DataProviders.Competitions;
using System.Threading.Tasks;

namespace Leagueen.Application.DataProviders
{
    public interface ICompetitionsProvider
    {
        Task<CompetitionsListDto> GetCompetitionsList();
        Task<CompetitionTeamsListDto> GetCompetitionTeamsList(string code);
    }
}
