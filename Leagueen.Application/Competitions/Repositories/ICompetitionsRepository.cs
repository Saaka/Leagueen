using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ICompetitionsRepository
    {
        Task<IEnumerable<Competition>> GetAllActiveCompetitions();
        Task<IEnumerable<CompetitionType>> GetAllActiveCompetitionTypesForProvider(DataProviderType providerType);
        Task<Competition> GetCompetitionByCode(string code);
        Task<DataProviderType> GetProviderTypeForCompetition(CompetitionType type);
        Task SaveCompetition(Competition competition);
        Task SaveCompetitions(IEnumerable<Competition> competitions);
    }
}
