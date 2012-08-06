using System.Collections.Generic;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Responses;
using Ninject;
using Ninject.Extensions.Conventions;
using Raven.Client;
using Raven.Client.Embedded;

namespace Candidate.Nancy.Selfhosted
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        private readonly ILogger _logger;
        private EmbeddableDocumentStore _documentStore;

        public Bootstrapper()
        {
            _logger = new ConsoleLogger();            
        }

        protected override void RegisterInstances(IKernel container, IEnumerable<InstanceRegistration> instanceRegistrations)
        {
            base.RegisterInstances(container, instanceRegistrations);

            SetupLogger(container);
            SetupRavenDB(container);
        }

        private void SetupRavenDB(IKernel container)
        {
            _documentStore = new EmbeddableDocumentStore { DataDirectory = "" };
            _documentStore.Initialize();

            container.Bind<IDocumentStore>().ToConstant(_documentStore);
            container.Bind<IDocumentSession>().ToMethod(_ => _documentStore.OpenSession());
        }

        protected override void RequestStartup(IKernel container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            SetupFormsAuthentication(container, pipelines);
            SetupFirstLaunch(container, pipelines);
        }

        private void SetupLogger(IKernel container)
        {
            container.Bind<ILogger>().ToConstant(_logger);
        }

        private void SetupFirstLaunch(IKernel container, IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(context => CheckApplicationCorrectlyInstalled(container, context));
            pipelines.AfterRequest.AddItemToEndOfPipeline(context => RedirectToInstallation(container, context));
        }

        private Response CheckApplicationCorrectlyInstalled(IKernel container, NancyContext nancyContext)
        {
            var installer = container.Get<Installer>();
            nancyContext.Items["InstallerCheckResult"] = installer.Check();

            return nancyContext.Response;
        }

        private void RedirectToInstallation(IKernel container, NancyContext nancyContext)
        {
            if (nancyContext.Request.Url.Path.Contains("/install"))
            {
                return;
            }

            var applicationInstalled = (bool)nancyContext.Items["InstallerCheckResult"];
            if (!applicationInstalled)
            {
                nancyContext.Response = new RedirectResponse("/install");
            }
        }

        private static void SetupFormsAuthentication(IKernel container, IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration
                    {
                        RedirectUrl = "~/account/logon",
                        UserMapper = container.Get<IUserMapper>()
                    };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Bind(scanner => scanner
                .FromAssembliesMatching("Candidate.*")
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
