using System.Collections.Generic;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations
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
