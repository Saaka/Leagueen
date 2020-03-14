using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class UserAggregateRepository : IUserAggregateRepository
    {
        private readonly AppDbContext context;

        public UserAggregateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveUser(User user)
        {
            context.Attach(user);
            await context.SaveChangesAsync();
        }
    }
}
