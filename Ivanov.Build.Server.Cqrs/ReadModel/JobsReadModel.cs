using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivanov.Build.Server.Cqrs.ReadModel.DTO;

namespace Ivanov.Build.Server.Cqrs.ReadModel
{
    public class JobsReadModel : IJobsReadModel
    {
        public IList<JobDto> Jobs
        {
            get
            {
                using (var context = new DataModel.DataModelDataContext())
                {
                    var jobs = context.Jobs.Select(j => new JobDto { Name = j.JobName, LastRunTime = j.LastRun, Status = j.Status ?? (int)j.Status.Value });
                    return jobs.ToList();
                }
            }
        }

        public JobConfigurationDto GetConfigurationForJob(string jobName)
        {
            using (var context = new DataModel.DataModelDataContext())
            {
                var configuration = context.JobConfigurations.Where(j => j.JobName == jobName).Select(j => new JobConfigurationDto { BatchName = j.BatchName });
                return configuration.SingleOrDefault();
            }
        }
    }
}
