using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Ivanov.Build.Server.Cqrs.Events
{
    public class JobConfigurationAddedEvent : SourcedEvent
    {
        public string JobName { get; set; }
        public string BatchCommandName { get; set; }
    }
}
