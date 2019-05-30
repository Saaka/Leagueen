using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Leagueen.Domain.Enums;
using Leagueen.Application.Competitions.Models;
using Leagueen.Application.Models;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly AppDbContext context;

        public CompetitionsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CompetitionUpdateInfo>> GetAllActiveCompetitions()
        {
            var query = from c in context.Competitions
                        where c.IsActive == true
                        select new CompetitionUpdateInfo
                        {
                            CompetitionId = c.CompetitionId,
                            Code = c.Code,
                            LastProviderUpdate = c.LastProviderUpdate
                        };

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<CompetitionType>> GetAllActiveCompetitionTypesForProvider(DataProviderType providerType)
        {
            var query = from comp in context.Competitions
                        join prov in context.DataProviders on comp.DataProviderId equals prov.DataProviderId
                        where prov.Type == providerType && comp.IsActive
                        select comp.Type;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<DictionaryModel>> GetCurrentSeasonsDictionary()
        {
            var query = from comp in context.Competitions
                        join season in context.Seasons on comp.CompetitionId equals season.CompetitionId
                        where season.IsActive == true && comp.IsActive == true
                        select new DictionaryModel
                        {
                            Id = season.SeasonId,
                            Name = comp.Name + " " + season.StartDate.Year + "/" + season.EndDate.Year
                        };

            return await query.ToListAsync();
        }

        public async Task<DataProviderType> GetProviderTypeForCompetition(CompetitionType type)
        {
            var query = from c in context.Competitions
                        join p in context.DataProviders on c.DataProviderId equals p.DataProviderId
                        where c.IsActive == true && c.Type == type
                        select p.Type;

            return await query.FirstOrDefaultAsync();
        }
    }
}
