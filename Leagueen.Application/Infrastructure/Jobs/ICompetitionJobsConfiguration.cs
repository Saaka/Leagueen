using Leagueen.Domain.Enums;
using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure.Jobs
{
    public interface ICompetitionJobsConfiguration
    {
        Task<JobExecutionTime> GetExecutionTime(CompetitionType competitionType);
    }
}
