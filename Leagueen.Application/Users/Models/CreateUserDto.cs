using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Application.Users.Models
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Moniker { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
