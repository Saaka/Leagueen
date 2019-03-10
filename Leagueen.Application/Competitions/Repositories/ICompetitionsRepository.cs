using Leagueen.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ICompetitionsRepository
    {
        Task<IEnumerable<Competition>> GetAllCompetitions();
        Task SaveCompetition(Competition competition);
        Task SaveCompetitions(IEnumerable<Competition> competitions);
    }
}
