namespace Leagueen.Common
{
    public interface IAuthConfiguration
    {
        string Secret { get; }
        string Issuer { get; }
        int TokenExpirationDurationInMinutes { get; }
    }
}
