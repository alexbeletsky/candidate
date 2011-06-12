using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Utils
{
    public class LocalAppDataFolder
    {
        public static string Folder
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Candidate";
            }
        }
    }
}
