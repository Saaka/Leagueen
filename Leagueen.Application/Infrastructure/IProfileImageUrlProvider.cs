namespace Leagueen.Application.Infrastructure
{
    public interface IProfileImageUrlProvider
    {
        string GetImageUrl(string email);
    }
}
