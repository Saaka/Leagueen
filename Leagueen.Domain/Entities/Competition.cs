using System;
using System.Collections.Generic;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class Competition
    {
        public int CompetitionId { get; private set; }
        public CompetitionType Type { get; private set; }
        public CompetitionModel Model { get; set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int ExternalId { get; private set; }

        public virtual IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();
        public List<Season> _seasons = new List<Season>();

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

        public void AddSeason(Season season)
        {
            _seasons.Add(season);
        }

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
