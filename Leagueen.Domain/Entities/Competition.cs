using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool IsActive { get; private set; }
        public int DataProviderId { get; set; }
        public DateTime? LastProviderUpdate { get; private set; }

        public virtual IReadOnlyCollection<Season> Seasons => _seasons.AsReadOnly();
        protected List<Season> _seasons = new List<Season>();
        public virtual DataProvider DataProvider { get; private set; }

        private Competition() { }

        public Competition(CompetitionType type, CompetitionModel model, string name, string code, int externalId, bool isActive, DataProvider dataProvider)
        {
            Type = type;
            Model = model;
            Name = name;
            Code = code;
            ExternalId = externalId;
            IsActive = isActive;
            DataProvider = dataProvider;

            dataProvider.AddCompetition(this);
            ValidateCreation();
        }

        public Competition AddSeason(Season season)
        {
            if (Seasons.Any(x => x.ExternalId == season.ExternalId))
                throw new DomainException(ExceptionCode.SeasonAlreadyInCompetition);

            _seasons.Add(season);
            return this;
        }

        public Competition SetLastProviderUpdate(DateTime date)
        {
            LastProviderUpdate = date;
            return this;
        }

        public Season GetCurrentSeason()
        {
            return Seasons
                .FirstOrDefault(x => x.IsActive);
        }

        public Competition SetActiveState(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        private void ValidateCreation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ExceptionCode.CompetitionNameRequired);
            if (string.IsNullOrWhiteSpace(Code))
                throw new DomainException(ExceptionCode.CompetitionCodeRequired);
            if (ExternalId == 0)
                throw new DomainException(ExceptionCode.CompetitionExternalIdRequired);
            if (!Enum.IsDefined(typeof(CompetitionType), Type))
                throw new DomainException(ExceptionCode.CompetitionTypeInvalid);
            if (!Enum.IsDefined(typeof(CompetitionModel), Model))
                throw new DomainException(ExceptionCode.CompetitionModelInvalid);
        }
    }
}
