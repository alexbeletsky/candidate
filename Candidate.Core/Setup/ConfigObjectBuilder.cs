using System;
using System.IO;
using System.Linq;
using Bounce.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder {
        private IDirectoryProvider _directoryProvider;

        public ConfigObjectBuilder(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        // TODO: CreateConfigObject have a smell of "Monster method", have to be redesigned. Visitor pattern for configuration creation;
        public ConfigObject CreateConfigObject(SiteConfiguration siteConfiguration) {
            if (siteConfiguration == null) {
                throw new ArgumentNullException("siteConfiguration");
            }

            // TODO: hard coded values as framework version, target have to be moved to build configuration
             
            var configObject = new ConfigObject();

            if (siteConfiguration.Github != null && !string.IsNullOrEmpty(siteConfiguration.Github.Url)) {
                configObject.Git = new GitCheckout {
                    Repository = siteConfiguration.Github.Url,
                    Directory = _directoryProvider.Source,
                    Branch = siteConfiguration.Github.Branch
                };
            }

            if (siteConfiguration.Solution != null) {
                configObject.Solution = new VisualStudioSolution {
                    SolutionPath = GetSolutionPath(siteConfiguration, configObject),
                    Target = "Rebuild",
                    OutputDir = GetOutputDir()
                };

                if (siteConfiguration.Solution.IsRunTests) {
                    var directoryInfo = new DirectoryInfo(_directoryProvider.Build);
                 
                    configObject.Tests = new NUnitTests {
                        NUnitConsolePath = _directoryProvider.NUnitConsole,
                        FrameworkVersion = "4.0",
                        DllPaths = configObject.Solution.WhenBuilt(
                            () => directoryInfo.GetFiles("*.dll").Where(p => p.Name.Contains("Test") || 
                                p.Name.Contains("Tests")).Select(p => p.FullName))
                    };
                }
            }

            if (siteConfiguration.Iis != null) {
                configObject.WebSite = new Iis7WebSite {
                    Directory = GetSiteDirectory(siteConfiguration, configObject),
                    Name = siteConfiguration.Iis.SiteName,
                    Port = GetSitePort(siteConfiguration, configObject)
                };
            }

            return configObject;
        }

        private Task<string> GetOutputDir() {
            return _directoryProvider.Build;
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

            // TODO: this copy operation is a little hidden and not obvious, have to be fixed
            return new Copy() {
                FromPath = GetPublishedPath(config),
                ToPath = GetDeploymentPath(config),
                DeleteToDirectory = true
            }.ToPath;
        }

        private Task<string> GetPublishedPath(SiteConfiguration config) {
            return _directoryProvider.PublishedWebSites + "\\" + config.Solution.WebProject;
        }

        private string GetDeploymentPath(SiteConfiguration config) {
            return _directoryProvider.Deployment + "\\" + config.Iis.SiteName;
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
