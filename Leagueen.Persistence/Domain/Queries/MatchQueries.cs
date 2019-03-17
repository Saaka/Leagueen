using System.Collections.Generic;
using System.Threading.Tasks;
using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Persistence.Connections;

namespace Leagueen.Persistence.Domain.Queries
{
    public class MatchQueries : IMatchQueries
    {
        protected readonly IDbConnectionFactory dbConnectionFactory;

        public MatchQueries(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public Task<ICollection<CompetitionModel>> GetTodaysMatches()
        {
            throw new System.NotImplementedException();
        }
    }
}
