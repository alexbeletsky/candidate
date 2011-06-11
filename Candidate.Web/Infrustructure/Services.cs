using Candidate.Core.Settings;
using Ninject.Modules;

namespace Candidate.Infrustructure
{
    class Services : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsManager>().To<SettingsManager>();
        }
    }
}