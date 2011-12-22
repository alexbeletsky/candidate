using System.Collections.Generic;
using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Core.Settings.Model
{
    public class ConfigurationsList
    {
        public ConfigurationsList()
        {
            Configurations = new List<Configuration>();
        }

        public IList<Configuration> Configurations { get; set; }
    }
}
