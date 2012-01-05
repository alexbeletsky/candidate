
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Log;

namespace Candidate.Core.Setup
{
    public interface ISetup
    {
        SetupResult RunForConfig(ILogger logger, VisualStudioConfiguration config);
    }
}
