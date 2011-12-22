using System;
using Candidate.Core.Settings.Model;
using Candidate.Core.Settings.Model.Configurations;
using Candidate.Core.Utils;
using Candidate.Core.Settings.Extensions;

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
