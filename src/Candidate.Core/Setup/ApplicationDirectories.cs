using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidate.Core.Setup
{
    public class ApplicationDirectories
    {
        public void Setup()
        {
            var directories = new List<string>
                                  {
                                      Settings.ApplicationDirectories.Root,
                                      Settings.ApplicationDirectories.Database,
                                      Settings.ApplicationDirectories.Sites,
                                      Settings.ApplicationDirectories.Tools
                                  };

            directories.ForEach(CreateDirectoryIfNotExist);
        }

        private static void CreateDirectoryIfNotExist(string directoryName)
        {
            if (!Directory.Exists(Settings.ApplicationDirectories.Root))
            {
                Directory.CreateDirectory(Settings.ApplicationDirectories.Root);
            }            
        }
    }
}
