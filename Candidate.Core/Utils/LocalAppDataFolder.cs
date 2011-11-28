using System;
using System.IO;

namespace Candidate.Core.Utils
{
    public class LocalAppDataFolder
    {
        private static readonly string AppFolder = ".candidate";

        private LocalAppDataFolder() {

        }

        public static string Folder
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), AppFolder);
            }
        }
    }
}
