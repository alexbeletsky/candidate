
namespace Candidate.Core.Utils {
    public interface IDirectoryProvider {
        string JobName { set; }
        string Root { get; }
        string Job { get; }
        string Source { get; }
        string Logs { get; }
        string Settings { get; }
    }
}
