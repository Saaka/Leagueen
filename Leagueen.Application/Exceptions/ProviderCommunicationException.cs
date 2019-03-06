using System;

namespace Leagueen.Application.Exceptions
{
    public class ProviderCommunicationException : Exception
    {
        public ProviderCommunicationException(string message)
            : base(message)
        {
        }
    }
}
