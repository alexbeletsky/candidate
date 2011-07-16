
using Candidate.Core.System;
using Candidate.Core.Settings.Model;
using Candidate.Core.Log;

namespace Candidate.Core.Setup {
    public interface ISetup {
        void RunForConfig(ILogger logger, JobConfigurationModel config);
    }
}
