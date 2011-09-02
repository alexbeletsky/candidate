using Candidate.Core.Settings;
using Ninject.Modules;
using Candidate.Core.Utils;
using Candidate.Core.Setup;
using Bounce.Framework;
using Candidate.Core.Log;
using Candidate.Core.Services;

namespace Candidate.Infrustructure {
    class Services : NinjectModule {
        public override void Load() {
            Bind<ISettingsManager>().To<SettingsManager>();
            Bind<IDirectoryProvider>().To<DirectoryProvider>().InSingletonScope();
            Bind<ISetupFactory>().To<SetupFactory>();
            Bind<ITargetsObjectBuilder>().To<DefaultTargetsObjectBuilder>();
            Bind<ITargetsBuilder>().To<TargetsBuilder>();
            Bind<IBounceFactory>().To<BounceFactory>();
            Bind<ITargetsRetriever>().To<TargetsRetriever>();
            Bind<IConfigObjectBuilder>().To<ConfigObjectBuilder>();
            Bind<ILoggerFactory>().To<LoggerFactory>();
            Bind<IHashService>().To<HashService>();
        }
    }
}