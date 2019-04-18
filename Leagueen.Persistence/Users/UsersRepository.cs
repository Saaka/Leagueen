using AutoMapper;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Constants;
using Leagueen.Domain.Exceptions;
using Leagueen.Persistence.Identity;
using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppIdentityDbContext context;
        private readonly IMapper mapper;

        public UsersRepository(
            UserManager<ApplicationUser> userManager,
            AppIdentityDbContext context,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto userData)
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

            return await GetUserDto(applicationUser);
        }

        public async Task<UserDto> CreateAsync(CreateGoogleUserDto userData)
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

            return await GetUserDto(applicationUser);
        }

        public async Task<UserDto> GetUserByCredentials(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new RepositoryException(nameof(GetUserByCredentials));

            if (await userManager.CheckPasswordAsync(user, password))
                return await GetUserDto(user);

            return null;
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            return await GetUserDto(user);
        }

        public async Task<UserDto> GetUserByMoniker(string moniker)
        {
            var user = await context.Users
                .Where(x => x.Moniker == moniker)
                .FirstOrDefaultAsync();
            if (user == null) return null;

            return await GetUserDto(user);
        }

        public async Task<int?> GetUserIdByMoniker(string moniker)
        {
            var user = await context.Users
                .Where(x => x.Moniker == moniker)
                .FirstOrDefaultAsync();
            if (user == null) return null;

            return user.Id;
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
            return await UpdateUser(user, nameof(MergeUserWithGoogle));
        }

        public async Task<UserDto> UpdateExistingGoogleUser(string email, string imageUrl)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DomainException(Leagueen.Domain.Enums.ExceptionCode.UserNotFound);

            user.ImageUrl = imageUrl;
            return await UpdateUser(user, nameof(UpdateExistingGoogleUser));
        }

        private async Task<UserDto> UpdateUser(ApplicationUser user, string method)
        {
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
                return await GetUserDto(user);
            else
                throw new RepositoryException(method, result.Errors.Select(x => x.Code));
        }

        private async Task<UserDto> GetUserDto(ApplicationUser user)
        {
            var userDto = mapper.Map<UserDto>(user);
            userDto.IsAdmin = await userManager.IsInRoleAsync(user, UserRoles.Admin);

            return userDto;
        }

        public async Task<bool> IsDisplayNameInUse(int userId, string displayName)
        {
            return await context.Users
                .AnyAsync(x => x.Id != userId && x.DisplayName == displayName);
        }

        public async Task<UserDto> UpdateUserDisplayName(int userId, string displayName)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            user.DisplayName = displayName;

            return await UpdateUser(user, nameof(UpdateUserDisplayName));
        }
    }
}
