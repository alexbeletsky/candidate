using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Utils {
    public class DirectoryProvider : IDirectoryProvider {

        public DirectoryProvider(string jobName) {
            JobName = jobName;
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string jobName, string root) {
            JobName = jobName;
            Root = root;
        }

        public string Root {
            get;
            private set;
        }

        public string Job {
            get {
                return Root + "\\" + JobName;
            }
        }

        public string Source {
            get {
                return Job + "\\" + "src" + "\\";
            }
        }

        public string Logs {
            get {
                return Job + "\\" + "logs" + "\\";
            }
        }

        public string Settings {
            get {
                return Root + "\\" + "settings" + "\\";
            }
        }

        public string JobName { get; set; }
    }
}
