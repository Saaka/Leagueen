using System;

namespace Leagueen.Common
{
    public interface IGuid
    {
        Guid GetGuid();
        string GetNormalizedGuid();
    }
}
