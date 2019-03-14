using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class UpdateLog
    {
        public int UpdateLogId { get; private set; }
        public UpdateLogType LogType { get; private set; }
        public DateTime Date { get; private set; }

        private UpdateLog() { }
        public UpdateLog(UpdateLogType type, DateTime date)
        {
            LogType = type;
            Date = date;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (!Enum.IsDefined(typeof(UpdateLogType), LogType))
                throw new DomainException(ExceptionCode.UpdateLogTypeRequred);
            if (Date == null || Date == DateTime.MinValue)
                throw new DomainException(ExceptionCode.UpdateLogDateRequred);
        }
    }
}
