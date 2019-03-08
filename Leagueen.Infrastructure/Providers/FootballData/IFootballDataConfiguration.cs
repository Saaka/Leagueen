namespace Leagueen.Infrastructure.Providers.FootballData
{
    public interface IFootballDataConfiguration
    {
        string ApiToken { get; }
        string ApiUrl { get; }
        string ApiPlan { get; }
    }
}
