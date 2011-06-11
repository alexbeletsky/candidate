using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivanov.Build.Server.Cqrs.Commands;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using Ivanov.Build.Server.Cqrs.Domain;

namespace Ivanov.Build.Server.Cqrs.Executors
{
    public class AddNewJobCommandExecutor : CommandExecutorBase<AddNewJobCommand>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, AddNewJobCommand command)
        {
            var newJob = new Job(command.JobName);

            context.Accept();
        }
    }
}
