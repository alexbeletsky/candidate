using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Ivanov.Build.Server.Cqrs.Events;

namespace Ivanov.Build.Server.Cqrs.Domain
{
    public class JobConfiguration : AggregateRootMappedByConvention
    {
        public string JobName { get; set; }
        public string BatchCommandName { get; set; }

        public JobConfiguration(string jobName, string batchCommandName)
        {
            var e = new JobConfigurationAddedEvent
            {
                JobName = jobName,
                BatchCommandName = batchCommandName
            };

            ApplyEvent(e);
        }

        protected void OnJobConfigurationAdded(JobConfigurationAddedEvent e)
        {
            JobName = e.JobName;
            BatchCommandName = e.BatchCommandName;
        }
    }
}
