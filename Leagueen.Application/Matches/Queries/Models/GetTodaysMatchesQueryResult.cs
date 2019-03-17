using System.Collections.Generic;

namespace Leagueen.Application.Matches.Queries.Models
{
    public class GetTodaysMatchesQueryResult
    {
        public GetTodaysMatchesQueryResult()
        {
            Competitions = new List<CompetitionModel>();
        }
        public ICollection<CompetitionModel> Competitions { get; set; }
    }
}
