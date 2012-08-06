using System;
using System.IO;

namespace Candidate.Core.Settings
{
    public static class ApplicationDirectories
    {
        private static readonly string AppFolder = ".candidate";

        private static readonly string RootDirectory =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), AppFolder);

        public static string Root
        {
            get { return RootDirectory;  }
        }

        public static string Database
        {
            get { return Path.Combine(RootDirectory, "db"); }
        }

        public static string Sites
        {
            get { return Path.Combine(RootDirectory, "sites"); }
        }

        public static string Tools
        {
            get { return Path.Combine(RootDirectory, "tools"); }
        }
    }
}
