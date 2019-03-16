using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Application.DataProviders.Competitions
{
    public class CompetitionInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
