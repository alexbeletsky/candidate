using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using Ivanov.Build.Server.Core.Settings;

namespace Ivanov.Build.Server.Tests.Settings
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
            public DateTime LastAccess { get; set; }
        }

        [Test]
        public void SaveJobToFile()
        {
            var jobsList = new List<Job> { 
                new Job { Id = 0, Configuration = "Git", Name = "xxx" },
                new Job { Id = 1, Configuration = "Git", Name = "aaa" }
            };

            using (var stream = new FileStream("jobs.json", FileMode.OpenOrCreate))
            {
                var serializer = new JsonSerializer();
                var writer = new StreamWriter(stream);
                serializer.Serialize(writer, jobsList);
                writer.Close();
            }
        }

        [Test]
        public void AddNewJobObject()
        {
            using (var stream = new FileStream("jobs.json", FileMode.OpenOrCreate))
            {
                var serializer = new JsonSerializer();
                var streamReader = new StreamReader(stream);
                var reader = new JsonTextReader(streamReader);
                var jobsList = serializer.Deserialize<IList<Job>>(reader);
            }
        }

        [Test]
        public void StoreSettings()
        {
            using (var writer = new JsonTextWriter(new StreamWriter("dashboard.settings.json")))
            {
                var serializer = new JsonSerializer();
                var settings = new BuildServerSettings
                {
                    User = new User { FirstName = "Alexander", LastName = "Beletsky" },
                    Jobs = new List<Job> { new Job { Id = 0, Configuration = "Git", Name = "proj" } },
                    LastAccess = DateTime.Now
                };

                serializer.Serialize(writer, settings);
            }
        }

        [Test]
        public void SettingsManager_SaveSettings()
        {
            var settingsManager = new SettingsManager();
            var settings = new BuildServerSettings
            {
                User = new User { FirstName = "Alexander", LastName = "Beletsky" },
                Jobs = new List<Job> { new Job { Id = 0, Configuration = "Git", Name = "proj" } },
                LastAccess = DateTime.Now
            };

            settingsManager.SaveSettings(settings);
        }

        [Test]
        public void SettingsManager_ReadSettings()
        {
            var settingsManager = new SettingsManager();
            var settings = new BuildServerSettings
            {
                User = new User { FirstName = "Alexander", LastName = "Beletsky" },
                Jobs = new List<Job> { new Job { Id = 0, Configuration = "Git", Name = "proj" } },
                LastAccess = DateTime.Now
            };

            settingsManager.SaveSettings(settings);

            var readSettings = settingsManager.ReadSettings<BuildServerSettings>();

            Assert.That(readSettings.User.FirstName, Is.EqualTo("Alexander"));
        }
    }
}
