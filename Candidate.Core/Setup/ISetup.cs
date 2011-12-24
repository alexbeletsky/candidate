
using Candidate.Core.Log;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface ISetup
    {
        SetupResult RunForConfig(ILogger logger, VisualStudioConfiguration config);
    }
}
