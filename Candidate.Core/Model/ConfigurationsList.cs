using System.Collections.Generic;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Model
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
