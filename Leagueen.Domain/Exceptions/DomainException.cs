using Leagueen.Domain.Enums;
using System;

namespace Leagueen.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public ExceptionCode ExceptionCode { get; private set; }

        public DomainException(ExceptionCode code, string details = null)
            : base(details ?? code.ToString())
        {
            ExceptionCode = code;
        }
    }
}
