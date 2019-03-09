using System;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class Competition
    {
        private Competition() { }

        public Competition(CompetitionType type, CompetitionModel model, string name, string code, int externalId)
        {
            Type = type;
            Model = model;
            Name = name;
            Code = code;
            ExternalId = externalId;

            ValidateCreation();
        }

        public int CompetitionId { get; private set; }
        public CompetitionType Type { get; private set; }
        public CompetitionModel Model { get; set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int ExternalId { get; private set; }
        
        private void ValidateCreation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ExceptionCode.InvalidCompetitionName);
            if (string.IsNullOrWhiteSpace(Code))
                throw new DomainException(ExceptionCode.InvalidCompetitionCode);
            if (ExternalId == 0)
                throw new DomainException(ExceptionCode.InvalidCompetitionExternalId);
            if (!Enum.IsDefined(typeof(CompetitionType), Type))
                throw new DomainException(ExceptionCode.InvalidCompetitionType);
            if (!Enum.IsDefined(typeof(CompetitionModel), Model))
                throw new DomainException(ExceptionCode.InvalidCompetitionModel);
        }
    }
}
