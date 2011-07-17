using System;
using Bounce.Framework;
using Candidate.Core.Settings.Model;
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

            if (config.Iis != null) {
                configObject.WebSite = new Iis7WebSite {
                    Directory = GetSiteDirectory(config, configObject),
                    Name = config.Iis.SiteName,
                    Port = 8081
                };
            }

            return configObject;
        }

        private Task<string> GetSiteDirectory(JobConfigurationModel config, ConfigObject configObject) {
            if (config.Solution == null || configObject.Solution == null) {
                throw new Exception("Couldn't create configuration for IIS without solution file");
            }

            if (config.Solution.WebProject == null) {
                throw new Exception("Couldn't create configuration for IIS without web project name");
            }
                        
            return configObject.Solution.Projects[config.Solution.WebProject].ProjectDirectory;
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
