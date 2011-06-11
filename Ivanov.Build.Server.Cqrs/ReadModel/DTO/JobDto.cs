using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Cqrs.ReadModel.DTO
{
    public class JobDto
    {
        public string Name { get; set; }
        public DateTime? LastRunTime { get; set; }
        public int Status { get; set; }
    }
}
