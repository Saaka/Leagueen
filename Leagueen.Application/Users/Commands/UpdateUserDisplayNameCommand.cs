using Leagueen.Application.Requests;
using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class UpdateUserDisplayNameCommand : IRequest<RequestResultBase>
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
