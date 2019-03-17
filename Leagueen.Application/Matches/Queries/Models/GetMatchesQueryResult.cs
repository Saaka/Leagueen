using System.Collections.Generic;

namespace Leagueen.Application.Matches.Queries.Models
{
    public class GetMatchesQueryResult
    {
        public GetMatchesQueryResult()
        {
            Competitions = new List<CompetitionModel>();
        }
        public ICollection<CompetitionModel> Competitions { get; set; }
    }
}
