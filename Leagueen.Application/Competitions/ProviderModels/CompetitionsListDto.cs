using System.Collections.Generic;

namespace Leagueen.Application.Competitions.ProviderModels
{
    public class CompetitionsListDto
    {
        public CompetitionsListDto()
        {
            Competitions = new List<CompetitionDto>();
        }

        public int Count { get; set; }
        public List<CompetitionDto> Competitions { get; set; }
    }
}
