
using System;
namespace Candidate.Core.Utils
{

    // TODO: get rid of + "\\" operation, use Path.Combine instead

    public class DirectoryProvider : IDirectoryProvider
    {

        public DirectoryProvider()
        {
            Root = LocalAppDataFolder.Folder;
        }

        public DirectoryProvider(string siteName)
        {
            if (siteName == null)
            {
                throw new ArgumentNullException("siteName");
            }

            SiteName = siteName;
        }

        public DirectoryProvider(string siteName, string root)
            : this(siteName)
        {
            Root = root;
        }

        public string Root
        {
            get;
            private set;
        }

        public string Site
        {
            get
            {
                return Root + "\\sites\\" + SiteName;
            }
        }

        public string Sources
        {
            get
            {
                return Site + "\\src";
            }
        }

        public string Logs
        {
            get
            {
                return Site + "\\logs";
            }
        }

        public string Settings
        {
            get
            {
                return Root + "\\settings";
            }
        }

        public string Build
        {
            get
            {
                return Sources + "\\build";
            }
        }

        public string PublishedWebsites
        {
            get { return Build + "\\_PublishedWebsites"; }
        }

        public string SiteName
        {
            get;
            set;
        }

        // TODO: make auto deploy of tools on first start
        public string NUnitConsole
        {
            get
            {
                return Root + "\\tools\\NUnit\\nunit-console.exe";
            }
        }
    }
}
