using System.Collections.Generic;
using System.IO;
using Candidate.Core;
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

        public Bootstrapper(ILogger logger)
        {
            _logger = logger;

            SetupApplicationDirectory();
            SetupRavenDB();
        }

        protected override void RegisterInstances(IKernel container, IEnumerable<InstanceRegistration> instanceRegistrations)
        {
            base.RegisterInstances(container, instanceRegistrations);

            RegisterLogger(container);
            RegisterRavenDBSession(container);
            RegisterConventions(container);
        }

        private void SetupApplicationDirectory()
        {
            _logger.Info("Setting up application directories...");

            var setupDirectories = new Core.Setup.ApplicationDirectories();
            setupDirectories.Setup();
        }

        private void SetupRavenDB()
        {
            _logger.Info("Setting up document store...");

            _documentStore = new EmbeddableDocumentStore { DataDirectory = Core.Settings.ApplicationDirectories.Database };
            _documentStore.Initialize();
        }

        private void RegisterConventions(IKernel container)
        {
            container.Bind(scanner => scanner
                .FromAssembliesMatching("Candidate.*")
                .SelectAllClasses()
                .BindDefaultInterface());
        }

        private void RegisterRavenDBSession(IKernel container)
        {
            container.Bind<IDocumentStore>().ToConstant(_documentStore);
            container.Bind<IDocumentSession>().ToMethod(_ => _documentStore.OpenSession());
        }

        private void RegisterLogger(IKernel container)
        {
            container.Bind<ILogger>().ToConstant(_logger);
        }

        protected override void RequestStartup(IKernel container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            SetupRequestLogging(container, pipelines);
            SetupFormsAuthentication(container, pipelines);
        }

        private void SetupRequestLogging(IKernel container, IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(c =>
                                                                 {
                                                                    _logger.Debug(string.Format("Request {0} {1}", c.Request.Method, c.Request.Url));
                                                                     return c.Response;
                                                                 });
        }

        private void SetupFormsAuthentication(IKernel container, IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration
                    {
                        RedirectUrl = "~/account/login",
                        UserMapper = container.Get<IUserMapper>()
                    };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
    }
}
