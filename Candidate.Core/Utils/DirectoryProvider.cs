
using System;
namespace Candidate.Core.Utils {

    // TODO: get rid of + "\\" operation, use Path.Combine instead

    public class DirectoryProvider : IDirectoryProvider {
        private string _jobName;

        public DirectoryProvider() {
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string jobName) {
            _jobName = jobName;
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string jobName, string root) {
            _jobName = jobName;
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
                return Job + "\\src";
            }
        }

        public string Logs {
            get {
                return Job + "\\logs";
            }
        }

        public string Settings {
            get {
                return Root + "\\settings";
            }
        }

        public string Build {
            get {
                return Source + "\\build";
            }
        }

        public string PublishedWebSites {
            get { return Build + "\\_PublishedWebsites"; }
        }

        public string JobName {
            get {
                if (_jobName == null) {
                    throw new Exception("Job name has not been set");
                }

                return _jobName;
            }

            set {
                _jobName = value;
            }
        }


        public string NUnitConsole {
            get {
                return Root + "\\tools\\NUnit\\nunit-console.exe"; 
            }
        }
    }
}
