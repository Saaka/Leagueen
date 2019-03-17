namespace Leagueen.Application.Infrastructure.Jobs
{
    public class JobExecutionTime
    {
        public JobExecutionTime(int hour, int miniutes)
        {
            Hour = hour;
            Miniutes = miniutes;
        }

        public int Hour { get; }
        public int Miniutes { get; }
    }
}
