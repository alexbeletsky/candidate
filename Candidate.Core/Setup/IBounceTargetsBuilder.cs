using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public interface IBounceTargetsBuilder {
        IEnumerable<Target> BuildTargetsFromConfig(JobConfigurationModel config); 
    }
}
