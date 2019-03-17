using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Application.Matches.Queries.Models
{
    public class CompetitionModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public List<MatchModel> Matches { get; set; }
    }
}
