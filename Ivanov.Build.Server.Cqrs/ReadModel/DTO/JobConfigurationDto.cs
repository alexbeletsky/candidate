using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Cqrs.ReadModel.DTO
{
    public class JobConfigurationDto
    {
        public Guid Id { get; set; }
        public string BatchName { get; set; }
    }
}
