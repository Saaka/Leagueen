using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ISeasonsRepository
    {
        Task<Season> GetSeasonInfo(int seasonId);
        Task<Season> GetCurrentSeason(string competitionCode);
        Task SaveSeason(Season season);
    }
}
