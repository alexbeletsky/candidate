
namespace Candidate.Core.Commands
{
    public interface ICommand
    {
        string Executable { get; }
        string Arguments { get; }
    }
}
