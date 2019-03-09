using Leagueen.Application.Competitions.ProviderModels;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions
{
    public interface ICompetitionsProvider
    {
        Task<CompetitionListDto> GetCompetitionsList();
    }
}
