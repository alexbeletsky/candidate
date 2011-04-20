using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ivanov.Build.Server.Areas.Dashboard.Models
{
    public class DashboardSettings
    {
        public DashboardSettings()
        {
            Jobs = new List<Job>();
        }

        public IList<Job> Jobs { get; set; }
    }
}