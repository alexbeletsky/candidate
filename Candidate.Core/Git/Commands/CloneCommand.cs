using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Git.Commands
{
    public class CloneCommand : ICommand
    {
        private string _url;

        public CloneCommand(string url)
        {
            _url = url;
        }

        public string Batch
        {
            get
            {
                return string.Format(@"git clone {0}", _url);
            }
        }
    }
}
