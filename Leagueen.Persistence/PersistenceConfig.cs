namespace Leagueen.Persistence
{
    public class PersistenceConfig
    {
        public const string AppConnectionString = nameof(AppConnectionString);

        public const string DefaultSchema = "leagueen";
        public const string DefaultMigrationsTable = "MigrationsLeagueen";

        public const string DefaultIdentitySchema = "leagueenidentity";
        public const string DefaultIdentityMigrationsTable = "MigrationsIdentityLeagueen";
    }
}
