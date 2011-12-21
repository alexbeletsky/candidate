using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Settings
{
    public static class SettingsManagerExtensions
    {
        public static void SaveSiteConfiguration(this ISettingsManager settingsManager, string jobName, Action<SiteConfiguration> UpdateConfig)
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var currentConfiguration = manager.ReadSettings<SitesConfigurationList>();
                var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (siteConfiguration == null)
                {
                    siteConfiguration = new SiteConfiguration { JobName = jobName };
                    currentConfiguration.Configurations.Add(siteConfiguration);
                }

                UpdateConfig(siteConfiguration);
            }
        }

        public static void DeleteSiteConfiguration(this ISettingsManager settingsManager, string jobName)
        {
            using (var manager = new AutoSaveSettingsManager(settingsManager))
            {
                var currentConfiguration = manager.ReadSettings<SitesConfigurationList>();
                var jobToDelete = currentConfiguration.Configurations.Where(j => j.JobName == jobName).SingleOrDefault();
                
                currentConfiguration.Configurations.Remove(jobToDelete);
            }
        }
    }
}
