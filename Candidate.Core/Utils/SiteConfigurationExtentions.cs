using System;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Utils {
    public static class SiteConfigurationExtentions {
        public static string GetSiteUrl(this Iis config) {

            if (config.Port == 0) {
                return string.Format("http://{0}", config.SiteName);
            }

            return string.Format("http://{0}:{1}", config.SiteName, config.Port);
        }
    }
}