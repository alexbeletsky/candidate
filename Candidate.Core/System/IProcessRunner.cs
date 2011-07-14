
using Candidate.Core.Commands;

namespace Candidate.Core.System {

    public interface IProcessRunner {
        //void RunBatch(string pathToExecutable);
        void RunCommandSync(ICommand command);
    }
}
