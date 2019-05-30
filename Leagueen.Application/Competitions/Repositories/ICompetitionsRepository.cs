using Leagueen.Application.Competitions.Models;
using Leagueen.Application.Models;
using Leagueen.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ICompetitionsRepository
    {
        Task<IEnumerable<CompetitionUpdateInfo>> GetAllActiveCompetitions();
        Task<IEnumerable<CompetitionType>> GetAllActiveCompetitionTypesForProvider(DataProviderType providerType);
        Task<DataProviderType> GetProviderTypeForCompetition(CompetitionType type);
        Task<IEnumerable<SeasonCompetitionDictionaryModel>> GetCurrentSeasonsDictionary();
    }
}
