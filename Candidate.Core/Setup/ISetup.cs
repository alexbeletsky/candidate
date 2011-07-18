
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public interface ISetup {
        SetupResult RunForConfig(ILogger logger, JobConfigurationModel config);
    }
}
