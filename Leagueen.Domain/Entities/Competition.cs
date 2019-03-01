namespace Leagueen.Domain.Entities
{
    public class Competition
    {
        public int CompetitionId { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ExternalId { get; set; }
    }
}
