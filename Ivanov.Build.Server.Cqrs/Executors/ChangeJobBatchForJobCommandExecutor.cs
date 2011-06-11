using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ivanov.Build.Server.Cqrs.Commands;
using Ivanov.Build.Server.Cqrs.Domain;

namespace Ivanov.Build.Server.Cqrs.Executors
{
    public class ChangeJobBatchForJobCommandExecutor : CommandExecutorBase<ChangeBatchForJobCommand>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ChangeBatchForJobCommand command)
        {
            //var configuration = context.GetById<JobConfiguration>(command.Id);
        }
    }
}
