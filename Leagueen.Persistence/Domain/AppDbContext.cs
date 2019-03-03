using Leagueen.Domain.Entities;
using Leagueen.Persistence.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(PersistenceConstants.DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
                x => x.Namespace == typeof(CompetitionConfiguration).Namespace);
        }
    }
}
