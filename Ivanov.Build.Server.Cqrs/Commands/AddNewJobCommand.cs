using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Ivanov.Build.Server.Cqrs.Commands
{
    public class AddNewJobCommand : CommandBase
    {
        public string JobName { get; set; }
    }
}
