using Leagueen.Application.Models;
using System.Collections.Generic;

namespace Leagueen.Application.Competitions.Models
{
    public class GetSeasonsDictionaryQueryResult
    {
        public GetSeasonsDictionaryQueryResult()
        {
            Seasons = new List<DictionaryModel>();
        }

        public ICollection<DictionaryModel> Seasons { get; set; }
    }
}
