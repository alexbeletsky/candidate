using System;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup
{
    public class ConfigObjectBuilder : IConfigObjectBuilder
    {
        private readonly IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public ConfigObject CreateConfigObject(SiteConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            var configVisitor = new ConfigObjectCreatingNodeVisitor(_directoryProvider);
            config.Accept(configVisitor);

            return configVisitor.ConfigObject;
        }
    }
}
