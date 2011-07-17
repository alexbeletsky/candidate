
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public interface ISetup {
        void RunForConfig(ILogger logger, JobConfigurationModel config);
    }
}
