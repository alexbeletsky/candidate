
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;
using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface ISetup
    {
        SetupResult RunForConfig(ILogger logger, VisualStudioConfiguration config);
    }
}
