using Leagueen.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ISeasonsRepository
    {
        Task<Season> GetSeasonInfo(Guid seasonId);
        Task<Season> GetCurrentSeason(string competitionCode);
        Task SaveSeason(Season season);
    }
}
