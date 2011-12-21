using System.Collections.Generic;
using System.IO;
using Candidate.Core.Settings;
using Candidate.Core.Utils;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;

namespace Candidate.Tests.Settings
{
    [TestFixture]
    public class SettingsTests
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private static DirectoryProvider DirectoryProvider = new DirectoryProvider("SettingsTests", CurrentDirectory);

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(DirectoryProvider.Settings, true);
        }

        [Test]
        public void SettingsManager_SaveSettings()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var settings = new BuildServerSettings
            {
                User = new User { FirstName = "Alexander", LastName = "Beletsky" },
                Jobs = new List<Job> { new Job { Id = 0, Configuration = "Git", Name = "proj" } },
            };

            // act
            settingsManager.SaveSettings(settings);

            // post
            var restoredSettings = settingsManager.ReadSettings<BuildServerSettings>();
            Assert.That(Comparer.Compare(settings, restoredSettings), Is.True);
        }

        [Test]
        public void SettingManager_With_TrackableObjects()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);
            var settings = new BuildServerSettings
            {
                User = new User { FirstName = "Alexander", LastName = "Beletsky" },
                Jobs = new List<Job> { new Job { Id = 0, Configuration = "Git", Name = "proj" } },
            };

            settingsManager.SaveSettings(settings);

            // act
            using (var trackableSettingsManager = new TrackableSettingsManager(settingsManager))
            {
                var restoredSettings = trackableSettingsManager.ReadSettings<BuildServerSettings>();
                restoredSettings.User.FirstName = "John";
                restoredSettings.User.LastName = "Doe";
            }

            // post
            var changedSettings = settingsManager.ReadSettings<BuildServerSettings>();
            Assert.That(changedSettings.User.FirstName, Is.EqualTo("John"));
            Assert.That(changedSettings.User.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void ReadSettings_IfNoSettingsCreated_ReturnNewObject()
        {
            // arrange
            var settingsManager = new SettingsManager(DirectoryProvider);

            // act
            var settings = settingsManager.ReadSettings<NoSuchSettings>();

            // assert
            Assert.That(settings, Is.Not.Null);
        }

        internal class Job
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Configuration { get; set; }
        }

        internal class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        internal class BuildServerSettings
        {
            public IList<Job> Jobs { get; set; }
            public User User { get; set; }
        }

        internal class NoSuchSettings
        {

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
