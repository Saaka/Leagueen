using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Services
{
    public interface IUserContextDataProvider
    {
        Task<int> GetUser(HttpContext context);
    }
    public class UserContextDataProvider : IUserContextDataProvider
    {
        private const string SubClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        private const string ContextUserCachePrefix = "USR_CTX_";

        private readonly IUsersRepository usersRepository;
        private readonly IMemoryCache memoryCache;

        public UserContextDataProvider(
            IUsersRepository usersRepository,
            IMemoryCache memoryCache)
        {
            this.usersRepository = usersRepository;
            this.memoryCache = memoryCache;
        }

        public async Task<int> GetUser(HttpContext context)
        {
            string userCode = GetUserCodeFromContext(context);

            var userId = await GetUserId(userCode);
            return userId;
        }

        private string GetUserCodeFromContext(HttpContext context)
        {
            if (context.User == null
                || context.User.Claims == null
                || !context.User.HasClaim(x => x.Type == SubClaimType))
                throw new InvalidOperationException("Can't authenticate current user");

            var userCode = context.User.FindFirst(x => x.Type == SubClaimType).Value;
            return userCode;
        }

        private async Task<int> GetUserId(string moniker)
        {
            var cacheKey = $"{ContextUserCachePrefix}{moniker}";

            var userId = await memoryCache.GetOrCreateAsync(cacheKey, async (ce) =>
            {
                ce.SlidingExpiration = TimeSpan.FromMinutes(5);
                ce.AbsoluteExpiration = DateTime.Now.AddHours(1);

                var user = await usersRepository.GetUserIdByGuid(moniker);
                if (user == null)
                    throw new DomainException(Domain.Enums.ExceptionCode.UserNotFound);

                return user;
            });

            return userId.Value;
        }
    }
}
