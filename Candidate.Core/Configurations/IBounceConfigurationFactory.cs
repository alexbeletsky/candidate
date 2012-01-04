using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Configurations
{
    public interface IBounceConfigurationFactory
    {
        XCopyBounceConfiguration CreateFor(XCopyConfiguration configuration);
        BatchBounceConfiguration CreateFor(BatchConfiguration configuration);
        VisualStudioBounceConfiguration CreateFor(VisualStudioConfiguration configuration);
    }
}