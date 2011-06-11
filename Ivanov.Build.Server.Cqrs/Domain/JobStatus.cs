using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;

namespace Ivanov.Build.Server.Cqrs.Domain
{
    public class JobStatus : Entity<Job>
    {
        public enum Status
        {
            Unknown,
            InProgress,
            Success,
            Fail
        };

        public Status Value { get; set; }

        public JobStatus(Job parent, Guid entityId, Status status) : base(parent, entityId)
        {
            Value = status;
        }
    }
}
