using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Responses;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Candidate.Nancy.Selfhosted
{
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void RequestStartup(Ninject.IKernel container, global::Nancy.Bootstrapper.IPipelines pipelines, global::Nancy.NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            FormsAuthentication(container, pipelines);
            FirstLaunch(container, pipelines);
        }

        private void FirstLaunch(IKernel container, IPipelines pipelines)
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

        private static void FormsAuthentication(IKernel container, IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration
                    {
                        RedirectUrl = "~/account/logon",
                        UserMapper = container.Get<IUserMapper>()
                    };

            global::Nancy.Authentication.Forms.FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureRequestContainer(IKernel container, global::Nancy.NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Bind(scanner => scanner
                .FromAssembliesMatching("Candidate.*")
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}
