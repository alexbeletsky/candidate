using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Utils {
    public interface IDirectoryProvider {
        string Root { get; }
        string Job { get; }
        string Source { get; }
        string Logs { get; }
    }
}
