using System;

namespace Leagueen.Application.Requests
{
    public class GuidResult
    {
        public GuidResult(Guid guid)
        {
            Guid = guid;
        }
        public Guid Guid { get; private set; }
    }
}
