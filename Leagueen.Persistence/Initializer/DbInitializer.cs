using System.Threading.Tasks;
using Leagueen.Application.Infrastructure.DbInitializer;
using Leagueen.Persistence.Domain.Initializer;
using Leagueen.Persistence.Identity.Initializer;

namespace Leagueen.Persistence.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityDbInitializer identityDbInitializer;
        private readonly AppDbInitializer appDbInitializer;

        public DbInitializer(
            IdentityDbInitializer identityDbInitializer,
            AppDbInitializer appDbInitializer)
        {
            this.identityDbInitializer = identityDbInitializer;
            this.appDbInitializer = appDbInitializer;
        }

        public async Task ExecuteAsync()
        {
            await identityDbInitializer.ExecuteAsync();
            await appDbInitializer.ExecuteAsync();
        }
    }
}
