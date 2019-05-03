using Leagueen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ICompetitionsAggregateRepository
    {
        Task<Competition> GetCompetitionByCode(string code);
        Task SaveCompetition(Competition competition);
        Task SaveCompetitions(IEnumerable<Competition> competitions);
    }
}
