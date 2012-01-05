using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidate.Core.Utils
{
    public class DirectoryHelper
    {
        private readonly string _id;

        public DirectoryHelper(string id)
        {
            _id = id;
        }

        public static DirectoryHelper For()
        {
            return new DirectoryHelper(null);
        }

        public static DirectoryHelper For(string id)
        {
            return new DirectoryHelper(id);
        }

        public string RootDirectory
        {
            get { return LocalAppDataFolder.Folder; }
        }

        public string SettingsDirectory
        {
            get { return Path.Combine(RootDirectory, "settings"); }
        }

        public string SiteDirectory
        {
            get { return Path.Combine(RootSitesDirectory, _id); }
        }

        public string SourcesDirectory
        {
            get { return Path.Combine(SiteDirectory, "src"); }
        }

        public string LogsDirectory
        {
            get { return Path.Combine(SiteDirectory, "logs"); }
        }

        private string RootSitesDirectory
        {
            get { return Path.Combine(RootDirectory, "sites"); }
        }

        public string ToolsDirectory
        {
            get { return Path.Combine(RootDirectory, "tools"); }
        }
    }
}
