using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Leagueen.Domain.Entities
{
    public class Team
    {
        public int TeamId { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Tla { get; private set; }
        public string CrestUrl { get; private set; }
        public string Website { get; private set; }

        public virtual IReadOnlyCollection<TeamSeason> Seasons => _seasons.AsReadOnly();
        protected List<TeamSeason> _seasons = new List<TeamSeason>();
        public virtual IReadOnlyCollection<Season> WonSeasons => _wonSeasons.AsReadOnly();
        protected List<Season> _wonSeasons = new List<Season>();
        public virtual IReadOnlyCollection<Match> HomeMatches => _homeMatches.AsReadOnly();
        protected List<Match> _homeMatches = new List<Match>();
        public virtual IReadOnlyCollection<Match> AwayMatches => _awayMatches.AsReadOnly();
        protected List<Match> _awayMatches = new List<Match>();
        public virtual IReadOnlyCollection<TeamExternalMapping> ExternalMappings => _externalMappings.AsReadOnly();
        protected List<TeamExternalMapping> _externalMappings = new List<TeamExternalMapping>();

        private Team() { }

        public Team(string name, string shortName, string tla, string crestUrl = null, string website = null)
        {
            Name = name;
            ShortName = shortName;
            Tla = tla;
            CrestUrl = crestUrl;
            Website = website;

            ValidateCreation();
        }

        public Team AddExternalMapping(string externalId, DataProviderType providerType)
        {
            if (_externalMappings.Any(x => x.ProviderType == providerType))
                throw new DomainException(ExceptionCode.ProviderMappingAlreadyExists);

            _externalMappings.Add(new TeamExternalMapping(this, externalId, providerType));
            return this;
        }

        private void ValidateCreation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ExceptionCode.TeamNameRequired);
            if (string.IsNullOrWhiteSpace(ShortName))
                throw new DomainException(ExceptionCode.TeamShortNameRequired);
            if (string.IsNullOrWhiteSpace(Tla))
                throw new DomainException(ExceptionCode.TeamTlaRequired);
        }
    }
}
