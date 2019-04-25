using System;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class TeamExternalMapping
    {
        public int TeamId { get; private set; }
        public string ExternalId { get; private set; }
        public DataProviderType ProviderType { get; private set; }

        public virtual Team Team { get; private set; }

        public TeamExternalMapping(
            Team team,
            string externalId,
            DataProviderType providerType)
        {
            Team = team;
            ExternalId = externalId;
            ProviderType = providerType;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (Team == null)
                throw new DomainException(ExceptionCode.TeamRequired);
            if (string.IsNullOrEmpty(ExternalId))
                throw new DomainException(ExceptionCode.TeamExternalIdRequired);
            if (!Enum.IsDefined(typeof(DataProviderType), ProviderType))
                throw new DomainException(ExceptionCode.DataProviderTypeInvalid);
        }
    }
}
