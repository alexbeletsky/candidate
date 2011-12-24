using System;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Configurations
{
    public class ConfigurationsFactory : IConfigurationsFactory
    {
        public Configuration CreateConfiguration(ConfigurationType type, string id, string readableName)
        {
            switch (type)
            {
                case ConfigurationType.Batch:
                    return new BatchConfiguration { Id = id, ReadableName = readableName };

                case ConfigurationType.XCopy:
                    return new XCopyConfiguration { Id = id, ReadableName = readableName };

                case ConfigurationType.VisualStudio:
                    return new VisualStudioConfiguration { Id = id, ReadableName = readableName };

                default:
                    throw new NotSupportedException(string.Format("ConfigurationsFactory: Given type {0} is not supported", type));
            }
        }
    }
}