using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Commands.AppCmd
{
    public class StopSite : ICommand
    {
        private string _site;

        public StopSite(string site)
        {
            _site = site;
        }

        public string Executable
        {
            get
            {
                return "c:\\windows\\system32\\inetsrv\\appcmd.exe";
            }
        }

        public string Arguments
        {
            get 
            {
                return string.Format(@"stop site {0}", _site);
            }
        }
    }
}
