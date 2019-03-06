using RestSharp;

namespace Leagueen.Infrastructure.Http
{
    public interface IRestsharpClientFactory
    {
        IRestClient CreateClient(string url);
        IRestRequest CreateRequest(string resource, Method method);

    }

    public class RestsharpClientFactory : IRestsharpClientFactory
    {
        public IRestClient CreateClient(string url)
        {
            return new RestClient(url);
        }

        public IRestRequest CreateRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }
    }
}
