using System;
using System.IO;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    public class ConfigurationBuilderBase
    {
        private readonly string _id;
        private readonly string _deployDirectory;
        private readonly string _buildDirectory;

        public ConfigurationBuilderBase(string id, string deployDirectory, string buildDirectory = null)
        {
            _id = id;
            _deployDirectory = deployDirectory;
            _buildDirectory = buildDirectory;
        }

        public string DeploymentDirectory
        {
            get { return Path.Combine(_deployDirectory, _id); }
        }

        public string SourcesDirectory
        {
            get { return DirectoryHelper.For(_id).SourcesDirectory; }
        }

        public string BuildDirectory
        {
            get { return _buildDirectory != null ? Path.Combine(SourcesDirectory, _buildDirectory) : SourcesDirectory; }
        }

        public string NUnitConsole
        {
            get { return DirectoryHelper.For(_id).ToolsDirectory;  }
        }
    }
}