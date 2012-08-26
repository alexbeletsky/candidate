using System;
using System.Collections.Generic;
using Candidate.Nancy.Selfhosted.App.Infrastructure.Serializers;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Conventions;
using Ninject;
using Ninject.Extensions.Conventions;
using Raven.Client;
using Raven.Client.Embedded;
using Candidate.Core.Logger;

namespace Candidate.Nancy.Selfhosted.App
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

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(c => c.Serializers.Insert(0, typeof(JsonNetSerializer)));
            }
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            // static content
            nancyConventions.StaticContentsConventions.Clear();
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("scripts",
                                                                                                       "Client/scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("content",
                                                                                                       "Client/content"));
            // view location
            nancyConventions.ViewLocationConventions.Clear();
            nancyConventions.ViewLocationConventions.Add((viewName, model, contex) => string.Concat("Client/views/", viewName));
            nancyConventions.ViewLocationConventions.Add((viewName, model, contex) => string.Concat("Client/views/", contex.ModuleName, "/", viewName));
        }

        protected override Type RootPathProvider
        {
            get
            {
                return typeof(PathProvider);
            }
        }

//        protected override void ConfigureApplicationContainer(IKernel existingContainer)
//        {
//            base.ConfigureApplicationContainer(existingContainer);
//
//            var currentAssembly = GetType().Assembly;
//            ResourceViewLocationProvider.RootNamespaces.Add(currentAssembly, "Candidate.Nancy.SelfHosted.Views");
//        }
//
//        protected override NancyInternalConfiguration InternalConfiguration
//        {
//            get { return NancyInternalConfiguration.WithOverrides(x => x.ViewLocationProvider = typeof(ResourceViewLocationProvider)); }
//        }

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

            var setupDirectories = new Core.Setup.ApplicationDirectories(_logger);
            setupDirectories.Setup(_logger);
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
                                                                    _logger.Debug(string.Format("Request {0} {1} {2}", c.Request.Method, c.Request.Url, c.Request.Path));
                                                                     return c.Response;
                                                                 });
            pipelines.AfterRequest.AddItemToEndOfPipeline(c => _logger.Debug(string.Format("Response {0} {1}",
                                                                                           c.Response.StatusCode,
                                                                                           c.Response.ContentType)));
            pipelines.AfterRequest.AddItemToEndOfPipeline(c =>
                                                              {
                                                                  if (c.Response.StatusCode != HttpStatusCode.OK)
                                                                  {
                                                                      _logger.Debug(c.Trace.ToString());
                                                                  }
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
