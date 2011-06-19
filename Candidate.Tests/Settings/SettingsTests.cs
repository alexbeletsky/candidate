using System.Collections.Generic;
using Candidate.Core.Settings;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;

namespace Candidate.Tests.Settings
{
    [TestFixture]
    public class SettingsTests
    {
        public class Job
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Configuration { get; set; }
        }

        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class BuildServerSettings
        {
            public IList<Job> Jobs { get; set; }
            public User User { get; set; }
        }

        [Test]
        public void SettingsManager_SaveSettings()
        {
            // arrange
            var settingsManager = new SettingsManager();
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
            var settingsManager = new SettingsManager();
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

        private CompareObjects Comparer
        {
            get
            {
                return new CompareObjects();
            }
        }
    }
}
