using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure.Jobs
{
    public class CompetitionJobsConfiguration : ICompetitionJobsConfiguration
    {
        public async Task<JobExecutionTime> GetExecutionTime(CompetitionType type)
        {
            var hour = 3;
            int minutes = 0;
            foreach(CompetitionType competitionType in Enum.GetValues(typeof(CompetitionType)))
            {
                if (competitionType == type)
                    return new JobExecutionTime(hour, minutes);

                minutes += 2;
            }

            throw new DomainException(ExceptionCode.CompetitionTypeInvalid);
        }
    }
}
