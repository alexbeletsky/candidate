
using System;
namespace Candidate.Core.Utils {

    // TODO: get rid of + "\\" operation, use Path.Combine instead

    public class DirectoryProvider : IDirectoryProvider {
        private string _siteName;

        public DirectoryProvider() {
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string jobName) {
            _siteName = jobName;
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string jobName, string root) {
            _siteName = jobName;
            Root = root;
        }

        public string Root {
            get;
            private set;
        }

        public string Site {
            get {
                return Root + "\\sites\\" + SiteName;
            }
        }

        public string Sources {
            get {
                return Site + "\\src";
            }
        }

        public string Logs {
            get {
                return Site + "\\logs";
            }
        }

        public string Settings {
            get {
                return Root + "\\settings";
            }
        }

        public string Build {
            get {
                return Sources + "\\build";
            }
        }

        public string PublishedWebSites {
            get { return Build + "\\_PublishedWebsites"; }
        }

        public string SiteName {
            get {
                if (_siteName == null) {
                    throw new Exception("Site name has not been set");
                }

                return _siteName;
            }

            set {
                _siteName = value;
            }
        }

        // TODO: make auto deploy of tools on first start
        public string NUnitConsole {
            get {
                return Root + "\\tools\\NUnit\\nunit-console.exe"; 
            }
        }
    }
}
