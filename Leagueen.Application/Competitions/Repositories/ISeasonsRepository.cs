using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ISeasonsRepository
    {
        Task SaveSeason(Season season);
    }
}
