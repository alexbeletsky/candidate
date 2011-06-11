using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;
using Ivanov.Build.Server.Cqrs.Domain;

namespace Ivanov.Build.Server.Cqrs.Events
{
    [Serializable]
    public class JobAddedEvent : SourcedEvent
    {
        public string Name { get; set; }
        public DateTime? LastRunTime { get; set; }
        public JobStatus CurrentStatus { get; set; }
    }
}
