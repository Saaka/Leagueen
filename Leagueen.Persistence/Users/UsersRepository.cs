using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Exceptions;
using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task CreateAsync(CreateUserDto userData)
        {
            var applicationUser = new ApplicationUser
            {
                Email = userData.Email,
                UserName = userData.Email,
                DisplayName = userData.DisplayName,
                Moniker = userData.Moniker,
                ImageUrl = userData.ImageUrl
            };

            var result = await userManager.CreateAsync(applicationUser, userData.Password);
            if (!result.Succeeded)
                throw new RepositoryException("CreateUser", result.Errors.Select(x => x.Code));
        }

        public async Task CreateAsync(CreateGoogleUserDto userData)
        {
            var applicationUser = new ApplicationUser
            {
                Email = userData.Email,
                UserName = userData.Email,
                DisplayName = userData.DisplayName,
                Moniker = userData.Moniker,
                ImageUrl = userData.ImageUrl,
                GoogleId = userData.GoogleId
            };

            var result = await userManager.CreateAsync(applicationUser);
            if (!result.Succeeded)
                throw new RepositoryException("CreateGoogleUser", result.Errors.Select(x => x.Code));
        }
    }
}
