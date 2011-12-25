using Bounce.Framework;
using Candidate.Core.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Tasks
{
    internal class DeployWebsiteTask
    {
        private readonly Iis _iis;
        private readonly IDirectoryProvider _directoryProvider;

        public DeployWebsiteTask(Iis iis, IDirectoryProvider directoryProvider)
        {
            _iis = iis;
            _directoryProvider = directoryProvider;
        }

        public Iis7WebSite ToTask()
        {
            return new Iis7WebSite
                       {
                           Directory = _iis.DeployFolder
                       };
        }
    }
}