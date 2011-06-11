using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Commands.Git
{
    public class CloneCommand : ICommand
    {
        private string _url;
        private string _folder;

        public CloneCommand(string url, string folder)
        {
            _url = url;
            _folder = folder;
        }

        public string Arguments
        {
            get
            {
                return string.Format(@"clone {0} {1}", _url, _folder);
            }
        }

        public string Executable
        {
            get
            {
                return "git.exe";
            }
        }
    }
}
