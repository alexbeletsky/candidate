using Candidate.Core.Configurations.Bounce.Builders;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Bounce
{
    public class BounceConfigurationFactory : IBounceConfigurationFactory
    {
        private readonly IDirectoryProvider _directoryProvider;

        public BounceConfigurationFactory(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public XCopyBounceConfiguration CreateFor(XCopyConfiguration configuration)
        {
            return new XCopyBounceConfigurationBuilder(_directoryProvider).CreateConfig(configuration);
        }

        public BatchBounceConfiguration CreateFor(BatchConfiguration configuration)
        {
            return new BatchBounceConfigurationBuilder(_directoryProvider).CreateConfig(configuration);
        }

        public VisualStudioBounceConfiguration CreateFor(VisualStudioConfiguration configuration)
        {
            return new VisualStudioBounceConfigurationBuilder(_directoryProvider).CreateConfig(configuration);
        }
    }
}