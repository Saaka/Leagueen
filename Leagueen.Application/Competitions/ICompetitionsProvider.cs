using Leagueen.Application.Competitions.ProviderModels;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions
{
    public interface ICompetitionsProvider
    {
        Task<CompetitionsListDto> GetCompetitionsList();
        Task<CompetitionTeamsListDto> GetCompetitionTeamsList(string code);
    }
}
