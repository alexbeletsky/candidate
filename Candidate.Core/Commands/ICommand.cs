using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Commands
{
    public interface ICommand
    {
        string Executable { get; }
        string Arguments { get; }
    }
}
