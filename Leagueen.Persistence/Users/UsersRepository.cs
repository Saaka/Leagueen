using AutoMapper;
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
        private readonly IMapper mapper;

        public UsersRepository(
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
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

        public async Task<bool> GoogleUserExists(string email, string googleId)
        {
            var user = await userManager.FindByEmailAsync(email);

            return user != null && user.GoogleId == googleId;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            return user != null;
        }

        public async Task<UserDto> MergeUserWithGoogle(string email, string externalUserId, string imageUrl)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DomainException(Leagueen.Domain.Enums.ExceptionCode.UserNotFound);

            user.GoogleId = externalUserId;
            user.ImageUrl = imageUrl;
            return await UpdateUser(user);
        }

        public async Task<UserDto> UpdateExistingGoogleUser(string email, string imageUrl)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DomainException(Leagueen.Domain.Enums.ExceptionCode.UserNotFound);

            user.ImageUrl = imageUrl;
            return await UpdateUser(user);
        }

        private async Task<UserDto> UpdateUser(ApplicationUser user)
        {
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return mapper.Map<UserDto>(user);
            else
                throw new RepositoryException(nameof(MergeUserWithGoogle), result.Errors.Select(x => x.Code));
        }
    }
}
