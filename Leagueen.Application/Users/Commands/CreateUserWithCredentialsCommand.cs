﻿using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class CreateUserWithCredentialsCommand : IRequest<CreateUserCommandResult>
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
    }
}
