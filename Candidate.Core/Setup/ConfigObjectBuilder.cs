using System;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Extensions;
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

        public ConfigObject CreateConfigObject(VisualStudioConfiguration config)
        {
            var configVisitor = new ConfigObjectCreatingNodeVisitor(_directoryProvider);
            config.Visit(configVisitor);

            return configVisitor.ConfigObject;
        }
    }
}
