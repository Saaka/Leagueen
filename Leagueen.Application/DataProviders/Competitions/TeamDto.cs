using System.Collections.Generic;

namespace Leagueen.Application.DataProviders.Competitions
{
    public class TeamDto
    {
        public TeamDto()
        {
            ClubColors = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string CrestUrl { get; set; }
        public string Website { get; set; }
        public List<string> ClubColors { get; set; }
    }
}
