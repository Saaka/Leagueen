using Leagueen.Application.Matches.Queries.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Repositories
{
    public interface IGetTodaysMatchesQueryExecutor
    {
        Task<ICollection<CompetitionModel>> Run();
    }
}
