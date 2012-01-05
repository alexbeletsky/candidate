using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Setup
{
    public interface IConfigObjectBuilder
    {
        ConfigObject CreateConfigObject(VisualStudioConfiguration config);
    }
}
