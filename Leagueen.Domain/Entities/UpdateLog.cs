using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class UpdateLog
    {
        public int UpdateLogId { get; private set; }
        public UpdateLogType LogType { get; private set; }
        public DataProviderType ProviderType { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsExecuted { get; private set; }
        public CompetitionType? CompetitionType { get; private set; }

        private UpdateLog() { }
        public UpdateLog(UpdateLogType type, DataProviderType provider, DateTime date, bool isExecuted)
        {
            LogType = type;
            ProviderType = provider;
            Date = date;
            IsExecuted = isExecuted;

            ValidateCreation();
        }
        public UpdateLog(UpdateLogType type, DataProviderType provider, CompetitionType competitionType, DateTime date)
        {
            LogType = type;
            ProviderType = provider;
            Date = date;
            CompetitionType = competitionType;
            IsExecuted = true;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (!Enum.IsDefined(typeof(UpdateLogType), LogType))
                throw new DomainException(ExceptionCode.UpdateLogTypeRequred);
            if (!Enum.IsDefined(typeof(DataProviderType), ProviderType))
                throw new DomainException(ExceptionCode.UpdateLogProviderTypeRequred);
            if (Date == null || Date == DateTime.MinValue)
                throw new DomainException(ExceptionCode.UpdateLogDateRequred);
            if (LogType == UpdateLogType.Competition && CompetitionType == null)
                throw new DomainException(ExceptionCode.UpdateLogCompetitionRequiredForLogType);
            if (LogType == UpdateLogType.CurrentMatch && CompetitionType.HasValue)
                throw new DomainException(ExceptionCode.UpdateLogCompetitionInvalidForLogType);
        }
    }
}
