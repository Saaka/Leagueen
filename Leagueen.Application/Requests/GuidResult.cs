namespace Leagueen.Application.Requests
{
    public class GuidResult
    {
        public GuidResult(string guid)
        {
            Guid = guid;
        }
        public string Guid { get; private set; }
    }
}
