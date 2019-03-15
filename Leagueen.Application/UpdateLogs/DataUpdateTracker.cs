using Leagueen.Application.UpdateLogs.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs
{
    public class DataUpdateTracker
    {
        private readonly IUpdateLogsRepository updateLogsRepository;

        public DataUpdateTracker(IUpdateLogsRepository updateLogsRepository)
        {
            this.updateLogsRepository = updateLogsRepository;
        }

        public async Task Create()
        {

        }
    }
}
