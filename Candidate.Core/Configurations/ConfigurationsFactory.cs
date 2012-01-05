using System;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations
{
    public class ConfigurationsFactory : IConfigurationsFactory
    {
        public Configuration CreateConfiguration(string type, string id, string readableName)
        {
            switch (type)
            {
                case "batch":
                    return new BatchConfiguration { Id = id, ReadableName = readableName };

                case "xcopy":
                    return new XCopyConfiguration { Id = id, ReadableName = readableName };

                case "visualstudio":
                    return new VisualStudioConfiguration { Id = id, ReadableName = readableName };

                default:
                    throw new NotSupportedException(string.Format("ConfigurationsFactory: Given type {0} is not supported", type));
            }
        }
    }
}