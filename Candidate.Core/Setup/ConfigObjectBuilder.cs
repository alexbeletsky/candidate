using System;
using Bounce.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;
using System.IO;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder {
        private IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        public ConfigObject CreateConfigObject(SiteConfiguration config) {
            if (config == null) {
                throw new ArgumentNullException("config");
            }

            var configObject = new ConfigObject();

            if (config.Github != null && !string.IsNullOrEmpty(config.Github.Url)) {
                configObject.Git = new GitCheckout {
                    Repository = config.Github.Url,
                    Directory = _directoryProvider.Source,
                    Branch = config.Github.Branch
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
                    Port = GetSitePort(config, configObject)
                };
            }

            return configObject;
        }

        private Task<int> GetSitePort(SiteConfiguration config, ConfigObject configObject) {
            return config.Iis.Port != 0 ? config.Iis.Port : 8081; 
        }

        private Task<string> GetSiteDirectory(SiteConfiguration config, ConfigObject configObject) {
            if (config.Solution == null || configObject.Solution == null) {
                throw new Exception("Couldn't create configuration for IIS without solution file");
            }

            if (config.Solution.WebProject == null) {
                throw new Exception("Couldn't create configuration for IIS without web project name");
            }

            // TODO: put C:\sites\ to configuration
            return new Copy() { 
                FromPath = configObject.Solution.Projects[config.Solution.WebProject].ProjectDirectory, 
                ToPath = @"c:\sites\" + config.Iis.SiteName }.ToPath;
        }

        private Task<string> GetSolutionPath(SiteConfiguration config, ConfigObject configObject) {
            return configObject.Git != null ? GetSolutionPathFromGit(config, configObject) : GetSolutionPathFromDirectoryProvider(config);
        }

        private string GetSolutionPathFromDirectoryProvider(SiteConfiguration config) {
            return _directoryProvider.Source + "\\" + config.Solution.Name;
        }

        private static Task<string> GetSolutionPathFromGit(SiteConfiguration config, ConfigObject configObject) {
            return configObject.Git.Files[config.Solution.Name];
        }
    }
}
