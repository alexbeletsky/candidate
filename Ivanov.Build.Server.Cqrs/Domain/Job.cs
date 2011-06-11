using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivanov.Build.Server.Cqrs.Events;
using Ncqrs.Domain;

namespace Ivanov.Build.Server.Cqrs.Domain
{
    public class Job : AggregateRootMappedByConvention
    {
        public string Name { get; set; }
        public DateTime? LastRunTime { get; set; }
        public JobStatus CurrentStatus { get; set; }

        public Job(string name)
        {
            var e = new JobAddedEvent
            {
                Name = name,
                LastRunTime = null,
                CurrentStatus = new JobStatus(this, this.EventSourceId, JobStatus.Status.Unknown)
            };

            ApplyEvent(e);
        }

        protected void OnJobAdded(JobAddedEvent e)
        {
            Name = e.Name;
            LastRunTime = e.LastRunTime;
            CurrentStatus = e.CurrentStatus;
        }
    }
}
