using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Configurations.Bounce.Builders;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations
{
    public class BounceConfigurationFactory : IBounceConfigurationFactory
    {
        private readonly IDirectoryProvider _directoryProvider;

        public BounceConfigurationFactory(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public XCopyBounceConfiguration CreateForXCopy(Configuration configuration)
        {
            return new XCopyBounceConfigurationBuilder(_directoryProvider).CreateConfig(configuration);
        }
    }
}