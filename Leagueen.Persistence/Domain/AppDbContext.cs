using Leagueen.Domain.Entities;
using Leagueen.Persistence.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSeason> TeamSeasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(PersistenceConstants.DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
                x => x.Namespace == typeof(CompetitionConfiguration).Namespace);
        }
    }
}
