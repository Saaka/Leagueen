namespace Leagueen.Common
{
    public interface IGoogleConfiguration
    {
        string ClientId { get; }
        string ClientKey { get; }
        string ValidationEndpoint { get; }
    }
}
