using System;
using System.Collections.Generic;
using System.Linq;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class DataProvider
    {
        public int DataProviderId { get; private set; }
        public DataProviderType Type { get; private set; }
        public string Name { get; private set; }
        
        public virtual IReadOnlyCollection<Competition> Competitions => _competitions.AsReadOnly();
        protected List<Competition> _competitions = new List<Competition>();

        private DataProvider() { }
        public DataProvider(DataProviderType type, string name)
        {
            Type = type;
            Name = name;

            ValidateCreation();
        }

        public DataProvider AddCompetition(Competition competition)
        {
            if (_competitions.Any(x => x.Type == competition.Type))
                throw new DomainException(ExceptionCode.DataProviderAlreadyConatinsCompetition, $"CompatitionType: {competition.Type}");

            _competitions.Add(competition);
            return this;
        }

        private void ValidateCreation()
        {
            if (!Enum.IsDefined(typeof(DataProviderType), Type))
                throw new DomainException(ExceptionCode.DataProviderTypeInvalid);
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ExceptionCode.DataProviderNameRequired);
        }
    }
}
