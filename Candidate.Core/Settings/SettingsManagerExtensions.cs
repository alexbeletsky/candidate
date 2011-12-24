using System;
using System.Linq;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings.Exceptions;

namespace Candidate.Core.Settings
{
    public static class SettingsManagerExtensions
    {
        public static void SaveConfiguration<T>(this ISettingsManager settingsManager, T configurationToSave) where T : Configuration
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var storedList = manager.ReadSettings<ConfigurationsList>();
                var storedConfiguration = (T)storedList.Configurations.SingleOrDefault(c => c.Id == configurationToSave.Id);

                if (storedConfiguration == null)
                {
                    storedList.Configurations.Add(configurationToSave);
                }
            }
        }

        public static T ReadConfiguration<T>(this ISettingsManager settingsManager, string jobName) where T : Configuration, new()
        {
            return settingsManager.ReadConfiguration<T>(c => c.Id == jobName);
        }

        public static T ReadConfiguration<T>(this ISettingsManager settingsManager, Func<Configuration, bool> predicate) where T : Configuration, new()
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
    }
}
