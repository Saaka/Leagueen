using System.Collections.Generic;

namespace Leagueen.Application.Matches.ProviderModels
{
    public class MatchListDto
    {
        public MatchListDto()
        {
            Matches = new List<MatchDto>();
        }

        public int Count { get; set; }
        public List<MatchDto> Matches { get; set; }
    }
}
