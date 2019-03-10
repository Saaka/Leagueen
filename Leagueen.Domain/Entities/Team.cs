﻿using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class Team
    {
        public int TeamId { get; private set; }
        public int ExternalId { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Tla { get; private set; }
        public string CrestUrl { get; private set; }
        public string Website { get; private set; }

        private Team() { }

        public Team(int externalId, string name, string shortName, string tla, string crestUrl = null, string website = null)
        {
            ExternalId = externalId;
            Name = name;
            ShortName = shortName;
            Tla = tla;
            CrestUrl = crestUrl;
            Website = website;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (ExternalId == 0)
                throw new DomainException(Enums.ExceptionCode.TeamExternalIdRequired);
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(Enums.ExceptionCode.TeamNameRequired);
            if (string.IsNullOrWhiteSpace(ShortName))
                throw new DomainException(Enums.ExceptionCode.TeamShortNameRequired);
            if (string.IsNullOrWhiteSpace(Tla))
                throw new DomainException(Enums.ExceptionCode.TeamTlaRequired);
        }
    }
}
