using MediatR;

namespace Leagueen.Application.Groups.Commands
{
    public class CreateGroupCommand : IRequest
    {
        public string Name { get; set; }
        public string GroupGuid { get; set; }
        public int OwnerId { get; set; }
    }
}
