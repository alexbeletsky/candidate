using Candidate.Core.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Candidate.Core.Setup
{
    public class ApplicationDirectories
    {
        private readonly ILogger _logger;

        public ApplicationDirectories(ILogger logger)
        {
            _logger = logger;
        }


        public void Setup(ILogger logger)
        {
            _logger.Info(string.Format("Application root folder at {0}", Settings.ApplicationDirectories.Root));

            var directories = new List<string>
                                  {
                                      Settings.ApplicationDirectories.Root,
                                      Settings.ApplicationDirectories.Database,
                                      Settings.ApplicationDirectories.Sites,
                                      Settings.ApplicationDirectories.Tools
                                  };

            directories.ForEach(CreateDirectoryIfNotExist);
        }

        private void CreateDirectoryIfNotExist(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                _logger.Info(string.Format("  Creating directory {0}", directoryName));

                Directory.CreateDirectory(directoryName);
            }
        }
    }
}
