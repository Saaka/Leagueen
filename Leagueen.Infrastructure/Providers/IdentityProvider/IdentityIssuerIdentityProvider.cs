using Leagueen.Application.Users.Models;
using Leagueen.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Providers.IdentityProvider
{
    public class IdentityIssuerIdentityProvider : IIdentityProvider
    {
        private readonly IRestsharpClientFactory _clientFactory;

        public IdentityIssuerIdentityProvider(IRestsharpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDto> AuthUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
