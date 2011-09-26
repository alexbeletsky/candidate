using System;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder {
        private readonly IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        public ConfigObject CreateConfigObject(SiteConfiguration siteConfiguration) {
            if (siteConfiguration == null) {
                throw new ArgumentNullException("siteConfiguration");
            }

            var configVisitor = new ConfigObjectCreatingNodeVisitor(_directoryProvider);
            siteConfiguration.Accept(configVisitor);
            return configVisitor.ConfigObject;
        }
    }
}
