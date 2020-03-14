using Leagueen.Common;
using System;

namespace Leagueen.Infrastructure
{
    public class GuidProvider : IGuid
    {
        public Guid GetGuid() => Guid.NewGuid();
    }
}
