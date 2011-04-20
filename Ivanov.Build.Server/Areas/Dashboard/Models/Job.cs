using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ivanov.Build.Server.Areas.Dashboard.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastBuildDate { get; set; }
        public int Status { get; set; }
    }
}