using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Git
{
    interface ICommand
    {
        string Batch { get; }
    }
}
