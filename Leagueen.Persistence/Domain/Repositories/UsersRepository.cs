using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> GetUserByGuid(string guid)
        {
            guid = guid.ToUpper();
            var query = from user in _context.Users
                        where user.UserGuid == guid
                        select new UserDto
                        {
                            UserGuid = user.UserGuid,
                            DisplayName = user.DisplayName,
                            Email = user.Email,
                            ImageUrl = user.ImageUrl
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var query = from user in _context.Users
                        where user.UserId == userId
                        select new UserDto
                        {
                            UserGuid = user.UserGuid,
                            DisplayName = user.DisplayName,
                            Email = user.Email,
                            ImageUrl = user.ImageUrl
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int?> GetUserIdByGuid(string guid)
        {
            var query = from user in _context.Users
                        where user.UserGuid == guid
                        select user.UserId

            return await query.FirstOrDefaultAsync();
        }
    }
}
