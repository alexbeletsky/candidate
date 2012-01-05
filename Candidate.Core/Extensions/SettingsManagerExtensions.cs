using System;
using System.Linq;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Exceptions;

namespace Candidate.Core.Extensions
{
    public static class SettingsManagerExtensions
    {
        public static void SaveConfiguration<T>(this ISettingsManager settingsManager, T configurationToSave) where T : Configuration
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var configurations = manager.ReadSettings<ConfigurationsList>();
                var configuration = (T)configurations.Configurations.SingleOrDefault(c => c.Id == configurationToSave.Id);

                if (configuration == null)
                {
                    configurations.Configurations.Add(configurationToSave);
                }
            }
        }

        public static T ReadConfiguration<T>(this ISettingsManager settingsManager, string jobName) where T : Configuration
        {
            return settingsManager.ReadConfiguration<T>(c => c.Id == jobName);
        }

        public static T ReadConfiguration<T>(this ISettingsManager settingsManager, Func<Configuration, bool> predicate) where T : Configuration
        {
            var configuration = settingsManager.ReadSettings<ConfigurationsList>().Configurations.SingleOrDefault(predicate);

            if (configuration == null || !(configuration is T))
            {
                throw new ConfigurationNotFoundException();
            }

            return (T)configuration;
        }

        public static void UpdateConfiguration<T>(this ISettingsManager settingsManager, string jobName, Action<T> UpdateConfig) where T : Configuration, new()
        {
            settingsManager.UpdateConfiguration(c => c.Id == jobName, UpdateConfig);
        }

        public static void UpdateConfiguration<T>(this ISettingsManager settingsManager, Func<Configuration, bool> predicate, Action<T> UpdateConfig) where T : Configuration, new()
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var storedConfiguration = manager.ReadConfiguration<T>(predicate);

                UpdateConfig(storedConfiguration);
            }
        }

        public static void DeleteConfiguration(this ISettingsManager settingsManager, string id)
        {
            settingsManager.DeleteConfiguration(c => c.Id == id);
        }

        public static void DeleteConfiguration(this ISettingsManager settingsManager, Func<Configuration, bool> predicate)
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var configurations = manager.ReadSettings<ConfigurationsList>();
                var configurationToDelete = configurations.Configurations.SingleOrDefault(predicate);

                if (configurationToDelete == null)
                {
                    throw new ConfigurationNotFoundException();
                }

                configurations.Configurations.Remove(configurationToDelete);
            }
        }
    }
}
