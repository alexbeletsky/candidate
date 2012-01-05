using System;
using Bounce.Framework;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Tasks
{
    internal class DeployWebsiteTask
    {
        private readonly string _siteFolder;
        private readonly string _siteName;
        private readonly int _port;
        private readonly string _bindingsString;

        public DeployWebsiteTask(string siteFolder, string siteName, int port)
            : this(siteFolder, siteName, port, null)
        {

        }

        public DeployWebsiteTask(string siteFolder, string siteName, int port, string bindingsString)
        {
            if (string.IsNullOrEmpty(siteFolder))
            {
                throw new ArgumentNullException("siteFolder");
            }

            if (string.IsNullOrEmpty(siteName))
            {
                throw new ArgumentNullException("siteName");
            }

            if (port <= 0 && string.IsNullOrEmpty(bindingsString))
            {
                throw new ArgumentOutOfRangeException("port");
            }

            _siteFolder = siteFolder;
            _siteName = siteName;
            _port = port;

            // TODO: use binding information string
            _bindingsString = bindingsString;
        }


        public Iis7WebSite ToTask()
        {

            return new Iis7WebSite
                       {
                           Directory = _siteFolder,
                           Name = _siteName,
                           Port = _port
                       };
        }
    }
}