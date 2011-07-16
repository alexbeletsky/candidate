
using Candidate.Core.System;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public interface ISetup {
        void Execute(ILogger logger);
    }
}
