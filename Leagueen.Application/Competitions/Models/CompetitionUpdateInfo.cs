using System;

namespace Leagueen.Application.Competitions.Models
{
    public class CompetitionUpdateInfo
    {
        public int CompetitionId { get; set; }
        public string Code { get; set; }
        public DateTime? LastProviderUpdate { get; set; }
    }
}
