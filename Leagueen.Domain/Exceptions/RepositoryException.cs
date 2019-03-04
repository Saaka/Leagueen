using System;
using System.Collections.Generic;
using System.Linq;

namespace Leagueen.Domain.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string error)
            : this(error, new List<string> { error })
        {
        }
        public RepositoryException(string error, IEnumerable<string> details)
            : base(error)
        {
            Errors = details.ToList();
        }

        public IEnumerable<string> Errors { get; private set; }
    }

}
