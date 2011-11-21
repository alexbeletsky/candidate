using System;
using System.IO;
using System.Linq;
using Bounce.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Candidate.Core.Setup {
    public class ConfigObjectCreatingNodeVisitor : SiteConfigurationNodeVisitor {
        private readonly ConfigObject _configObject = new ConfigObject();
        private readonly IDirectoryProvider _directoryProvider;
        private Solution _solution;

        public ConfigObjectCreatingNodeVisitor(IDirectoryProvider provider) {
            _directoryProvider = provider;
        }

        public ConfigObject ConfigObject {
            get { return _configObject; }
        }

        public override void Visit(SiteConfiguration node) {
            // NOP
        }

        public override void Visit(GitHub node) {
            if (!string.IsNullOrEmpty(node.Url)) {
                _configObject.Git = new GitCheckout {
                    Repository = node.Url,
                    Directory = _directoryProvider.Sources,
                    Branch = node.Branch
                };
            }
        }

        public override void Visit(Solution node) {
            _solution = node;
            _configObject.Solution = new VisualStudioSolution {
                SolutionPath = GetSolutionPath(node, _configObject),
                Target = GetTarget(node),
                Configuration = GetConfiguration(node),
                OutputDir = GetOutputDir()
            };

            if (node.IsRunTests) {
                var directoryInfo = new DirectoryInfo(_directoryProvider.Build);

                _configObject.Tests = new NUnitTests {
                    NUnitConsolePath = _directoryProvider.NUnitConsole,
                    FrameworkVersion = GetFrameworkVersion(node),
                    DllPaths = _configObject.Solution.WhenBuilt(
                        () => directoryInfo.GetFiles("*.dll").Where(p => p.Name.Contains("Test") ||
                            p.Name.Contains("Tests")).Select(p => p.FullName))
                };
            }
        }

        public override void Visit(Iis node) {
            if (_solution == null || _configObject.Solution == null) {
                throw new Exception("Couldn't create configuration for IIS without solution file");
            }

            if (_solution.WebProject == null) {
                throw new Exception("Couldn't create configuration for IIS without web project name");
            }

            _configObject.WebSite = new Iis7WebSite {
                Directory = GetSiteDirectory(node, _solution),
                Name = node.SiteName,
                Port = GetSitePort(node)
            };

            if (node.Bindings != null) {
                _configObject.WebSite.Bindings = GetBindings(node.Bindings);
            }
        }

        private Task<IEnumerable<Iis7WebSiteBinding>> GetBindings(string bindingInformation) {
            var bounceBindingsList = new List<Iis7WebSiteBinding>();

            var splittedBindingString = bindingInformation.Split(';');
            foreach (var bindingString in splittedBindingString) {
                var protocol = bindingString.Substring(0, bindingString.IndexOf(":"));
                var information = bindingString.Substring(bindingString.IndexOf(":") + 1);

                var binding = new Iis7WebSiteBinding {
                    Protocol = protocol,
                    Information = information
                };

                bounceBindingsList.Add(binding);
            }

            return bounceBindingsList;
        }

        public override void Visit(Post node) {
            if (_configObject.Solution != null) {
                _configObject.PostBuild = new ShellCommand {
                    Exe = node.PostBatch,
                    WorkingDirectory = _configObject.Solution.SolutionDirectory
                };
            }
        }

        private static Task<int> GetSitePort(Iis iis) {
            return iis.Port != 0 ? iis.Port : 8081;
        }

        private Task<string> GetSiteDirectory(Iis iis, Solution solution) {
            // TODO: this copy operation is a little hidden and not obvious, have to be fixed
            return new Copy() {
                FromPath = GetPublishedPath(solution),
                ToPath = GetDeploymentPath(iis),
                DeleteToDirectory = true
            }.ToPath;
        }

        private Task<string> GetPublishedPath(Solution solution) {
            return _directoryProvider.PublishedWebSites + "\\" + solution.WebProject;
        }

        private string GetDeploymentPath(Iis iis) {
            return iis.DeployFolder + "\\" + iis.SiteName;
        }

        private Task<string> GetOutputDir() {
            return _directoryProvider.Build;
        }

        private Task<string> GetFrameworkVersion(Solution solution) {
            return solution.NUnitRuntimeVersions[solution.SelectedNUnitRuntimeVersion];
        }

        private Task<string> GetConfiguration(Solution solution) {
            return solution.Configurations[solution.SelectedConfiguration];
        }

        private Task<string> GetTarget(Solution solution) {
            return solution.Targets[solution.SelectedTarget];
        }

        private Task<string> GetSolutionPath(Solution solution, ConfigObject configObject) {
            return configObject.Git != null ? GetSolutionPathFromGit(solution, configObject) : GetSolutionPathFromDirectoryProvider(solution);
        }

        private string GetSolutionPathFromDirectoryProvider(Solution solution) {
            return _directoryProvider.Sources + "\\" + solution.Name;
        }

        private Task<string> GetSolutionPathFromGit(Solution solution, ConfigObject configObject) {
            return configObject.Git.Files[solution.Name];
        }
    }
}