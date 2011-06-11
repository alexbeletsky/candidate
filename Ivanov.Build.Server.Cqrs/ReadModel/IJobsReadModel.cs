using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivanov.Build.Server.Cqrs.Domain;
using Ivanov.Build.Server.Cqrs.ReadModel.DTO;

namespace Ivanov.Build.Server.Cqrs.ReadModel
{
    public interface IJobsReadModel
    {
        IList<JobDto> Jobs { get; }
        JobConfigurationDto GetConfigurationForJob(string jobName); 
    }
}
