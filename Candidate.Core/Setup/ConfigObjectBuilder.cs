using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;
using Bounce.Framework;
using System.Dynamic;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder {
        private IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        public ConfigObject CreateConfigObject(JobConfigurationModel config) {
            if (config == null) {
                throw new ArgumentNullException("config");
            }

            var configObject = new ConfigObject();

            if (config.Github != null) {
                configObject.Git = new GitCheckout {
                    Repository = config.Github.Url,
                    Directory = _directoryProvider.Source
                };
            }

            if (config.Solution != null) {
                configObject.Solution = new VisualStudioSolution {
                    SolutionPath = GetSolutionPath(config, configObject)
                };
            }

            return configObject;
        }

        private Task<string> GetSolutionPath(JobConfigurationModel config, ConfigObject configObject) {
            return configObject.Git != null ? GetSolutionPathFromGit(config, configObject) : GetSolutionPathFromDirectoryProvider(config);
        }

        private string GetSolutionPathFromDirectoryProvider(JobConfigurationModel config) {
            return _directoryProvider.Source + config.Solution.Name;
        }

        private static Task<string> GetSolutionPathFromGit(JobConfigurationModel config, ConfigObject configObject) {
            return configObject.Git.Files[config.Solution.Name];
        }
    }
}
