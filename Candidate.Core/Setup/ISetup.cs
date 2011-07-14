
using Candidate.Core.System;
namespace Candidate.Core.Setup {
    public interface ISetup {
        void Execute(ILogger logger);
    }
}
