using System;

namespace Candidate.Core.Utils
{
    public class LocalAppDataFolder
    {
        public static string Folder
        {
            get
            {
                // TODO: consider another special folder, maybe ~/.candidate
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Candidate";
            }
        }
    }
}
