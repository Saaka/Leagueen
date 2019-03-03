using Leagueen.Application.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Application.Users.Commands
{
    public class AuthenticateUserWithGoogleCommand : IRequest<AuthUserCommandResult>
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string GoogleId { get; set; }
    }
}
