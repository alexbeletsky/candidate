using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Ivanov.Build.Server.Cqrs.Commands
{
    public class ChangeBatchForJobCommand : CommandBase
    {
        public Guid Id { get; set; }
        public string BatchName { get; set; }
    }
}
