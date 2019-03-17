using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Common;
using Leagueen.Persistence.Connections;

namespace Leagueen.Persistence.Domain.Queries
{
    public class GetTodaysMatchesQueryExecutor : IGetTodaysMatchesQueryExecutor
    {
        protected readonly IDbConnectionFactory dbConnectionFactory;
        private readonly IDateTime dateTime;

        public GetTodaysMatchesQueryExecutor(
            IDbConnectionFactory dbConnectionFactory,
            IDateTime dateTime)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.dateTime = dateTime;
        }

        public async Task<ICollection<CompetitionModel>> Run()
        {
            var date = dateTime.GetUtcNow().Date;
            using (var connection = dbConnectionFactory.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync(GetTodaysMatchesQuery, new { date }))
                {
                    var competitions = await multi.ReadAsync<CompetitionModel>();
                    var matches = await multi.ReadAsync<MatchModel>();

                    foreach (var grouped in matches.GroupBy(x => x.CompetitionId))
                    {
                        var competition = competitions.FirstOrDefault(x => x.CompetitionId == grouped.Key);
                        if (competition == null) continue;

                        competition.Matches = grouped.OrderBy(x => x.Date).ToList();
                    }

                    return competitions.Where(x => x.Matches.Any()).ToList();
                }
            }
        }

        private const string GetTodaysMatchesQuery = @"
        SELECT DISTINCT	C.CompetitionId, C.Code, C.Name, C.Model
        FROM	leagueen.Competitions C
		        JOIN leagueen.Seasons S ON C.CompetitionId = S.SeasonId
		        JOIN leagueen.Matches M ON S.SeasonId = M.SeasonId
        WHERE	CAST(M.[Date] AS DATE) = @date;
        SELECT	M.MatchId, HT.[Name] AS [HomeTeam], AT.[Name] AS [AwayTeam], ISNULL(MS.FullTimeHome, 0) AS [HomeScore], ISNULL(MS.FullTimeAway, 0) AS [AwayScore], M.Result, M.Status, M.Date, S.CompetitionId
        FROM	leagueen.Matches M 
		        JOIN leagueen.Seasons S ON M.SeasonId = S.SeasonId
		        JOIN leagueen.Teams HT ON M.HomeTeamId = HT.TeamId
		        JOIN leagueen.Teams AT ON M.AwayTeamId = AT.TeamId
		        LEFT JOIN leagueen.MatchScores MS ON M.MatchId = MS.MatchId
        WHERE	CAST(M.[Date] AS Date) = @date
        ORDER BY S.CompetitionId, M.Date;";
    }
}
