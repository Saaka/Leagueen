using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure.DbInitializer
{
    public interface IDbInitializer
    {
        Task ExecuteAsync();
    }
}
