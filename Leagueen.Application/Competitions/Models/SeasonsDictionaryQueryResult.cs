using Leagueen.Application.Models;
using System.Collections.Generic;

namespace Leagueen.Application.Competitions.Models
{
    public class GetSeasonsDictionaryQueryResult
    {
        public GetSeasonsDictionaryQueryResult()
        {
            Seasons = new List<SeasonCompetitionDictionaryModel>();
        }

        public ICollection<SeasonCompetitionDictionaryModel> Seasons { get; set; }
    }
}
