using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivanov.Build.Server.Cqrs.Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Ivanov.Build.Server.Cqrs.Denormalizers
{
    public class AddJobDenormalizer : IEventHandler<JobAddedEvent>
    {
        public void Handle(JobAddedEvent evnt)
        {
            using (var context = new DataModel.DataModelDataContext())
            {
                var job = new DataModel.Job
                {
                    JobName = evnt.Name,
                    LastRun = evnt.LastRunTime,
                    Status = (int)evnt.CurrentStatus.Value
                };

                context.Jobs.InsertOnSubmit(job);
                context.SubmitChanges();
            }
        }
    }
}
