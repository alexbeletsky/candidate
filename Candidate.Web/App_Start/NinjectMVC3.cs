[assembly: WebActivator.PreApplicationStartMethod(typeof(Candidate.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Candidate.App_Start.NinjectMVC3), "Stop")]

namespace Candidate.App_Start
{
    using Bounce.Framework;
    using Candidate.Core.Log;
    using Candidate.Core.Services;
    using Candidate.Core.Settings;
    using Candidate.Core.Setup;
    using Candidate.Core.Utils;
    using Candidate.Infrustructure.Authentication;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISettingsManager>().To<SettingsManager>();
            kernel.Bind<IDirectoryProvider>().To<DirectoryProvider>().InSingletonScope();
            kernel.Bind<ISetupFactory>().To<SetupFactory>();
            kernel.Bind<ITargetsObjectBuilder>().To<DefaultTargetsObjectBuilder>();
            kernel.Bind<ITargetsBuilder>().To<TargetsBuilder>();
            kernel.Bind<IBounceFactory>().To<BounceFactory>();
            kernel.Bind<ITargetsRetriever>().To<TargetsRetriever>();
            kernel.Bind<IConfigObjectBuilder>().To<ConfigObjectBuilder>();
            kernel.Bind<ILoggerFactory>().To<LoggerFactory>();
            kernel.Bind<IHashService>().To<HashService>();
            kernel.Bind<IAuthentication>().To<Authentication>();
        }
    }
}
