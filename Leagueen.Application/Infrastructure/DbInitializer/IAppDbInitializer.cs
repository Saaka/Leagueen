using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure.DbInitializer
{
    public interface IAppDbInitializer
    {
        Task ExecuteAsync();
    }
}
