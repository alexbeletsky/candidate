using Candidate.Core.Settings;

namespace Candidate.Core.Setup {
    public interface ISetupManager {
        ISetup CreateSetup(ISettingsManager settingsManager, string jobName);
    }
}
