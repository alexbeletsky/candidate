using System;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder 
    {
        private readonly IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        // TODO: hard coded values as framework version, target have to be moved to build configuration
        public ConfigObject CreateConfigObject(SiteConfiguration siteConfiguration)
        {
            if (siteConfiguration == null)
            {
                throw new ArgumentNullException("siteConfiguration");
            }

            var visitor = new ConfigObjectCreatingNodeVisitor(_directoryProvider);
            siteConfiguration.Accept(visitor);
            return visitor.ConfigObject;
        }
    }
}
