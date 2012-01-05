using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Exceptions;
using Candidate.Core.Utils;
using NUnit.Framework;
using KellermanSoftware.CompareNetObjects;

namespace Candidate.Tests.Settings
{
    public class SettingsWithTypesTests
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        private static readonly DirectoryProvider DirectoryProvider = new DirectoryProvider("SettingsTests",
                                                                                            CurrentDirectory);

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(DirectoryProvider.Settings, true);
        }

        [Test]
        public void should_read_xcopy_settings()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new XCopyConfiguration
                                            {
                                                Id = jobName,
                                                Github = new Github {Branch = "master", Url = "git@github.com"},
                                                Iis = new Iis {SiteName = jobName, Port = 2222},
                                            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            var actualConfiguration = settingsManager.ReadConfiguration<XCopyConfiguration>(jobName);

            // assert
            Assert.That(Comparer.Compare(actualConfiguration, expectedConfiguration), Is.True);
        }

        [Test]
        public void should_update_xcopy_configuration()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new XCopyConfiguration
                                            {
                                                Id = jobName,
                                                Github = new Github {Branch = "master", Url = "git@github.com"},
                                                Iis = new Iis {SiteName = jobName, Port = 2222},
                                            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            settingsManager.UpdateConfiguration<XCopyConfiguration>(jobName, c => c.Github.Branch = "develop");

            // assert
            var actualConfiguration = settingsManager.ReadConfiguration<XCopyConfiguration>(jobName);
            Assert.That(actualConfiguration.Github.Branch, Is.EqualTo("develop"));
        }

        [Test]
        public void should_read_batch_settings()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new BatchConfiguration
                                            {
                                                Github = new Github { Branch = "master" },
                                                Id = jobName,
                                                Iis = new Iis { SiteName = jobName, Port = 2222 },
                                                Batch = new Batch { BuildScript = "build.bat" }
                                            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            var actualConfiguration = settingsManager.ReadConfiguration<BatchConfiguration>(jobName);

            // assert
            Assert.That(Comparer.Compare(actualConfiguration, expectedConfiguration), Is.True);
        }

        [Test]
        public void should_update_batch_configuration()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new BatchConfiguration
            {
                Github = new Github { Branch = "master" },
                Id = jobName,
                Iis = new Iis { SiteName = jobName, Port = 2222 },
                Batch = new Batch { BuildScript = "build.bat" }
            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            settingsManager.UpdateConfiguration<BatchConfiguration>(jobName, c => c.Batch.BuildScript = "exec.bat");

            // assert
            var actualConfiguration = settingsManager.ReadConfiguration<BatchConfiguration>(jobName);
            Assert.That(actualConfiguration.Batch.BuildScript, Is.EqualTo("exec.bat"));
        }

        [Test]
        public void should_read_visual_studio_configuration()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new VisualStudioConfiguration
                                            {
                                                Github = new Github { Branch = "master" },
                                                Id = jobName,
                                                Iis = new Iis { SiteName = jobName, Port = 2222 },
                                            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            var actualConfiguration = settingsManager.ReadConfiguration<VisualStudioConfiguration>(jobName);

            // assert
            Assert.That(Comparer.Compare(actualConfiguration, expectedConfiguration), Is.True);
        }

        [Test]
        public void should_update_visual_studio_configuration()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var jobName = "test";
            var expectedConfiguration = new VisualStudioConfiguration
            {
                Github = new Github { Branch = "master" },
                Id = jobName,
                Iis = new Iis { SiteName = jobName, Port = 2222 },
            };

            settingsManager.SaveConfiguration(expectedConfiguration);

            // act
            settingsManager.UpdateConfiguration<VisualStudioConfiguration>(jobName, c => c.Iis.Port= 3333);

            // assert
            var actualConfiguration = settingsManager.ReadConfiguration<VisualStudioConfiguration>(jobName);
            Assert.That(actualConfiguration.Iis.Port, Is.EqualTo(3333));
        }

        [Test]
        public void should_support_the_mix_of_configurations_in_one_configuration_list()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);

            settingsManager.SaveConfiguration(new BatchConfiguration { Id = "test 1" });
            settingsManager.SaveConfiguration(new VisualStudioConfiguration { Id = "test 2" });
            settingsManager.SaveConfiguration(new XCopyConfiguration { Id = "test 3" });

            // act
            var batchConfiguration = settingsManager.ReadConfiguration<BatchConfiguration>(_ => _.Id == "test 1");
            var vsConfiguration = settingsManager.ReadConfiguration<VisualStudioConfiguration>(_ => _.Id == "test 2");
            var xCopyConfiguration = settingsManager.ReadConfiguration<XCopyConfiguration>(_ => _.Id == "test 3");

            // assert
            Assert.That(batchConfiguration, Is.Not.Null);
            Assert.That(vsConfiguration, Is.Not.Null);
            Assert.That(xCopyConfiguration, Is.Not.Null);
        }

        [Test]
        public void should_throw_exception_if_required_for_configuration_of_wrong_type()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);

            settingsManager.SaveConfiguration(new BatchConfiguration { Id = "test 1" });
            settingsManager.SaveConfiguration(new VisualStudioConfiguration { Id = "test 2" });
            settingsManager.SaveConfiguration(new XCopyConfiguration { Id = "test 3" });

            // act
            Assert.Throws<ConfigurationNotFoundException>(() => settingsManager.ReadConfiguration<BatchConfiguration>(_ => _.Id == "test 2"));
        }

        [Test]
        public void should_throw_exception_if_configuration_does_not_exist()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);

            settingsManager.SaveConfiguration(new BatchConfiguration { Id = "test 1" });

            // act
            Assert.Throws<ConfigurationNotFoundException>(() => settingsManager.ReadConfiguration<BatchConfiguration>(_ => _.Id == "test 2"));
        }

        [Test]
        public void should_delete_configuration()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);

            settingsManager.SaveConfiguration(new BatchConfiguration { Id = "test 1" });
            settingsManager.SaveConfiguration(new VisualStudioConfiguration { Id = "test 2" });
            settingsManager.SaveConfiguration(new XCopyConfiguration { Id = "test 3" });

            // act
            settingsManager.DeleteConfiguration(c => c.Id == "test 2");

            // assert
            Assert.Throws<ConfigurationNotFoundException>(() => settingsManager.ReadConfiguration<VisualStudioConfiguration>(c => c.Id == "test 2"));
        }

        internal CompareObjects Comparer
        {
            get
            {
                return new CompareObjects();
            }
        }

    }
}
