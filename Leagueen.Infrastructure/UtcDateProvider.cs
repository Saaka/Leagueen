using Leagueen.Common;
using System;

namespace Leagueen.Infrastructure
{
    public class UtcDateProvider : IDateTime
    {
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}
