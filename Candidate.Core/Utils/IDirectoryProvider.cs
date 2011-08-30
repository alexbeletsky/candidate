using System.Collections;


namespace Candidate.Core.Utils {
    public interface IDirectoryProvider {
        string JobName { set; }
        string Root { get; }
        string Job { get; }
        string Source { get; }
        string Build { get; }
        string Logs { get; }
        string Settings { get; }
        string PublishedWebSites { get; }
        string Deployment { get; }
        string NUnitConsole { get; }
    }
}
