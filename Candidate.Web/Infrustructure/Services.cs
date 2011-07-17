using Candidate.Core.Settings;
using Ninject.Modules;
using Candidate.Core.Utils;

namespace Candidate.Infrustructure
{
    class Services : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsManager>().To<SettingsManager>();
            Bind<IDirectoryProvider>().To<DirectoryProvider>();
        }
    }
}