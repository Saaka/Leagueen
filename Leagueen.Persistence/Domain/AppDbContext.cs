using Leagueen.Domain.Entities;
using Leagueen.Persistence.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DataProvider> DataProviders { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamExternalMapping> TeamExternalMappings { get; set; }
        public DbSet<TeamSeason> TeamSeasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchScore> MatchScores { get; set; }
        public DbSet<UpdateLog> UpdateLogs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupSettings> GroupSettings { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendshipRequest> FriendshipRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(PersistenceConstants.DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
                x => x.Namespace == typeof(CompetitionConfiguration).Namespace);
        }
    }
}
