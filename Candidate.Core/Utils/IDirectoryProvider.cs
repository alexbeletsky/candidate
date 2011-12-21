using System.Collections;

// TODO: redesign provider to avoid singleton usage of it.. 
namespace Candidate.Core.Utils
{
    public interface IDirectoryProvider
    {
        string SiteName { get; set; }
        string Root { get; }
        string Site { get; }
        string Sources { get; }
        string Build { get; }
        string Logs { get; }
        string Settings { get; }
        string PublishedWebsites { get; }
        string NUnitConsole { get; }
    }
}
