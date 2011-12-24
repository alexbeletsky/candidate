using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class FooTests
    {
        [SetUp]
        public void Setup()
        {
            DirectoryProvider = new Mock<IDirectoryProvider>();
        }

        protected Mock<IDirectoryProvider> DirectoryProvider { get; set; }

        [Test]
        public void foo()
        {
            var configuration = new XCopyConfiguration
            {
                Github = new Github { Branch = "master", Url = "git@git.com" },
                Iis = new Iis { Port = 9090, SiteName = "x", DeployFolder = "c:\\sites" }
            };

            var bounceConfig = CreateBounceConfig(configuration);

            Assert.That(bounceConfig.CheckoutSources, Is.Not.Null);
            Assert.That(bounceConfig.XCopyFiles, Is.Not.Null);
            Assert.That(bounceConfig.DeployWebsite, Is.Not.Null);
        }

        private XCopyBounceConfiguration CreateBounceConfig(Configuration configuration)
        {
            return new XCopyBounceConfigurationBuilder(DirectoryProvider.Object).CreateConfig(configuration);
        }
    }

    internal class XCopyBounceConfigurationBuilder
    {
        private readonly IDirectoryProvider _directoryProvider;

        public XCopyBounceConfigurationBuilder(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public XCopyBounceConfiguration CreateConfig(Configuration configuration)
        {
            var xCopyConfiguration = configuration as XCopyConfiguration;

            if (xCopyConfiguration == null)
            {
                throw new ConfigurationTypeNotSupported();
            }

            return new XCopyBounceConfiguration
            {
                CheckoutSources = new CheckoutSourcesTask(xCopyConfiguration.Github, _directoryProvider).ToTask(),
                DeployWebsite = new DeployWebsiteTask(xCopyConfiguration.Iis, _directoryProvider).ToTask()
            };
        }
    }

    internal class DeployWebsiteTask
    {
        private readonly Iis _iis;
        private readonly IDirectoryProvider _directoryProvider;

        public DeployWebsiteTask(Iis iis, IDirectoryProvider directoryProvider)
        {
            _iis = iis;
            _directoryProvider = directoryProvider;
        }

        public Iis7WebSite ToTask()
        {
            return new Iis7WebSite
            {

            };
        }
    }

    internal class CheckoutSourcesTask
    {
        private readonly Github _github;
        private readonly IDirectoryProvider _directoryProvider;

        public CheckoutSourcesTask(Github github, IDirectoryProvider directoryProvider)
        {
            _github = github;
            _directoryProvider = directoryProvider;
        }

        public GitCheckout ToTask()
        {
            return new GitCheckout { Repository = _github.Url, Branch = _github.Branch, Directory = _directoryProvider.Sources };
        }
    }

    internal class ConfigurationTypeNotSupported : Exception
    {
    }

    internal class XCopyBounceConfiguration
    {
        public GitCheckout CheckoutSources { get; set; }
        public Iis7WebSite DeployWebsite { get; set; }
    }
}
