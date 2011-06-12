using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Commands.Git
{
    public class PullCommand : ICommand
    {
        private string _origin;

        public PullCommand(string origin)
        {
            _origin = origin;
        }

        public string Arguments
        {
            get
            {
                return string.Format(@"pull {0}", _origin);
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
