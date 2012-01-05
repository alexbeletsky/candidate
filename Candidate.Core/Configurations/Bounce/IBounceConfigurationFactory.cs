using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations.Bounce
{
    public interface IBounceConfigurationFactory
    {
        XCopyBounceConfiguration CreateFor(XCopyConfiguration configuration);
        BatchBounceConfiguration CreateFor(BatchConfiguration configuration);
        VisualStudioBounceConfiguration CreateFor(VisualStudioConfiguration configuration);
    }
}