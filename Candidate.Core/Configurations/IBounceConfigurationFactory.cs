using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Configurations
{
    public interface IBounceConfigurationFactory
    {
        XCopyBounceConfiguration CreateForXCopy(Configuration configuration);
    }
}