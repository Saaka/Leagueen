namespace Leagueen.Common
{
    public interface IFacebookConfiguration
    {
        string FacebookAppId { get; }
        string FacebookAppSecret { get; }
        string FacebookValidationEndpoint { get; }
    }
}
