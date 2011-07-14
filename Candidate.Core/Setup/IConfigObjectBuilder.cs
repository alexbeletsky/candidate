using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public interface IConfigObjectBuilder {
        dynamic CreateConfigObject(JobConfigurationModel config);
    }
}
