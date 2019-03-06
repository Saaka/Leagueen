using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueen.Common
{
    public interface IGoogleConfiguration
    {
        string ClientId { get; }
        string ClientKey { get; }
        string ValidationEndpoint { get; }
    }
}
