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

            siteConfiguration.Accept(ConfigVisitor);
            return ConfigVisitor.ConfigObject;
        }

        public ConfigObjectCreatingNodeVisitor ConfigVisitor {
            get {
                return new ConfigObjectCreatingNodeVisitor(_directoryProvider);
            }
        }
    }
}
