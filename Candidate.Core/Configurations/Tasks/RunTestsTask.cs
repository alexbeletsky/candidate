using System.IO;
using System.Linq;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    public class RunTestsTask 
    {
        private readonly bool _isRunTests;
        private readonly string _buildDirectory;
        private readonly string _nUnitConsole;
        private readonly string _framework;
        private readonly VisualStudioSolution _solution;

        public RunTestsTask(bool isRunTests, string buildDirectory, string nUnitConsole, string framework, VisualStudioSolution solution)
        {
            _isRunTests = isRunTests;
            _buildDirectory = buildDirectory;
            _nUnitConsole = nUnitConsole;
            _framework = framework;
            _solution = solution;
        }

        public NUnitTests ToTask()
        {
            if (!_isRunTests)
            {
                return null;
            }

            var directoryInfo = new DirectoryInfo(_buildDirectory);

            return new NUnitTests
                       {
                           NUnitConsolePath = _nUnitConsole,
                           FrameworkVersion = _framework,
                           DllPaths = _solution.WhenBuilt(
                               () => directoryInfo.GetFiles("*.dll").Where(p => p.Name.Contains("Test") || p.Name.Contains("Tests")).Select(p => p.FullName))
                       };
        }
    }
}