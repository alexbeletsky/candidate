using System.IO;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    public class BuildSolutionTask
    {
        private readonly string _sourcesDirectory;
        private readonly string _solutionName;
        private readonly string _target;
        private readonly string _configuration;
        private readonly string _buildDirectory;

        public BuildSolutionTask(string sourcesDirectory, string solutionName, string target, string configuration, string buildDirectory)
        {
            _sourcesDirectory = sourcesDirectory;
            _solutionName = solutionName;
            _target = target;
            _configuration = configuration;
            _buildDirectory = buildDirectory;
        }

        public VisualStudioSolution ToTask()
        {
            return new VisualStudioSolution
                       {
                           SolutionPath = Path.Combine(_sourcesDirectory, _solutionName),
                           Target = _target,
                           Configuration = _configuration,
                           OutputDir = _buildDirectory
                       };
        }
    }
}