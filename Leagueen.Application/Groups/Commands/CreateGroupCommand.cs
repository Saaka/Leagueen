using Leagueen.Domain.Enums;
using MediatR;

namespace Leagueen.Application.Groups.Commands
{
    public class CreateGroupCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsForExactScore { get; set; }
        public int PointsForResult { get; set; }
        public GroupType Type { get; set; }
        public MatchResultResolveMode ResultResolveMode { get; set; }
        public GroupVisibility Visibility { get; set; }
        public string GroupGuid { get; set; }
        public int OwnerId { get; set; }
        public int? SeasonId { get; set; }
        public int? CompetitionId { get; set; }
    }
}
