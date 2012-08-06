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
            if (!Directory.Exists(Settings.ApplicationDirectories.Root))
            {
                Directory.CreateDirectory(Settings.ApplicationDirectories.Root);
            }

            if (!Directory.Exists(Settings.ApplicationDirectories.Database))
            {
                Directory.CreateDirectory(Settings.ApplicationDirectories.Database);
            }

            if (!Directory.Exists(Settings.ApplicationDirectories.Sites))
            {
                Directory.CreateDirectory(Settings.ApplicationDirectories.Sites);
            }

            if (!Directory.Exists(Settings.ApplicationDirectories.Tools))
            {
                Directory.CreateDirectory(Settings.ApplicationDirectories.Tools);
            }
        }
    }
}
