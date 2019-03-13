using System.Collections.Generic;

namespace Leagueen.Application.DataProviders.Competitions
{
    public class CompetitionTeamsListDto
    {
        public CompetitionTeamsListDto()
        {
            Teams = new List<TeamDto>();
        }
        public int Count { get; set; }
        public CompetitionSeasonDto Season { get; set; }
        public List<TeamDto> Teams { get; set; }
    }
}
