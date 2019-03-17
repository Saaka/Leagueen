using Leagueen.Domain.Enums;
using System.Collections.Generic;

namespace Leagueen.Application.Matches.Queries.Models
{
    public class CompetitionModel
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public CompetitionModelType Model { get; set; }
        public List<MatchModel> Matches { get; set; }
    }
}
