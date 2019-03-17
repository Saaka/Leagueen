using Leagueen.Application.Matches.Queries.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Repositories
{
    public interface IGetMatchesByDateQueryExecutor
    {
        Task<ICollection<CompetitionModel>> Run(DateTime date);
    }
}
