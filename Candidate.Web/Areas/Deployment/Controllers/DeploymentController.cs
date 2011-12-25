using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Bounce.Framework;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Log;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using Candidate.Infrustructure.Error;
using Candidate.Infrustructure.Filters;

namespace Candidate.Areas.Deployment.Controllers
{
    [Authorize]
    [HandleJsonError]
    public class DeploymentController : Controller
    {
        private ISettingsManager _settingsManager;
        private ISetupFactory _setupFactory;
        private ILoggerFactory _loggerFactory;
        private IDirectoryProvider _directoryProvider;

        public DeploymentController(ISettingsManager settingsManager, ISetupFactory setupFactory, ILoggerFactory loggerFactory, IDirectoryProvider directoryProvider)
        {
            _settingsManager = settingsManager;
            _setupFactory = setupFactory;
            _loggerFactory = loggerFactory;
            _directoryProvider = directoryProvider;
        }

        [HttpGet]
        public ActionResult Setup(string jobName)
        {
            throw new NotImplementedException();

            //ViewBag.Id = jobName;

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //if (!siteConfiguration.IsConfigured())
            //{
            //    return View("NotConfigured");
            //}

            //return View();
        }

        [HttpPost]
        public ActionResult StartSetup(string jobName)
        {
            throw new NotImplementedException();

            //var currentSettings = _settingsManager.ReadSettings<ConfigurationsList>().Configurations.Where(c => c.Id == jobName).SingleOrDefault();
            //if (currentSettings == null)
            //{
            //    throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            //}

            //return RunDeployAndLog(jobName, currentSettings);
        }

        [HttpPost]
        [ValidateToken]
        public ActionResult Hook(string jobName, string token, string payload)
        {
            throw new NotImplementedException();
            //var currentSettings = _settingsManager.ReadSettings<ConfigurationsList>().Configurations.Where(c => c.Id == jobName).SingleOrDefault();
            //if (currentSettings == null)
            //{
            //    throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            //}

            //// TODO: move this serialization to service
            //var payloadDeserialized = JsonConvert.DeserializeObject<GithubHookPayload>(payload);
            //var githubConfiguration = currentSettings.Github;

            //if (!IsHookForBranch(payloadDeserialized.Branch, githubConfiguration))
            //{
            //    return null;
            //}

            //return RunDeployAndLog(jobName, currentSettings);
        }

        private static bool IsHookForBranch(string payload, Github githubConfiguration)
        {
            return payload.Equals(githubConfiguration.Branch);
        }

        private ActionResult RunDeployAndLog(string jobName, VisualStudioConfiguration currentSettings)
        {
            _directoryProvider.SiteName = jobName;

            using (var logger = _loggerFactory.CreateLogger())
            {
                var setup = _setupFactory.CreateSetup();
                var result = setup.RunForConfig(logger, currentSettings);

                return Json(new { success = true, result = result });
            }
        }

        private void ThisHowISeeItShouldLookLike(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<XCopyConfiguration>(id);

            var configurationBuilder = new Deployer(_directoryProvider, _loggerFactory);
            configurationBuilder.DeployXCopyConfig(configuration);
        }

    }

    internal class Deployer
    {
        private readonly IDirectoryProvider _directoryProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly BounceConfigurationFactory _bounceConfigFactory;
        private readonly BounceFactory _bounceFactory;
        private readonly TargetsBuilder _bounceTargetsRunner;
        private readonly FileLogOptionsFactory _logOptionsFactory;

        public Deployer(IDirectoryProvider directoryProvider, ILoggerFactory loggerFactory)
        {
            _directoryProvider = directoryProvider;
            _loggerFactory = loggerFactory;

            _bounceConfigFactory = new BounceConfigurationFactory(_directoryProvider);
            _bounceFactory = new BounceFactory();
            _logOptionsFactory = new FileLogOptionsFactory();
            _bounceTargetsRunner = new TargetsBuilder();
        }

        public void DeployXCopyConfig(XCopyConfiguration configuration)
        {
            using (var logger = _loggerFactory.CreateLogger())
            {
                var bounceConfig = _bounceConfigFactory.CreateForXCopy(configuration);
                var bounceTargets = bounceConfig.ToTargets();
                var bounce = _bounceFactory.GetBounce(_logOptionsFactory.CreateLogOptions(logger, LogLevel.Debug));

                _bounceTargetsRunner.BuildTargets(bounce, bounceTargets, BounceCommandFactory.GetCommandByName("build"));
            }
        }
    }

    internal static class ConfigurationsExtensions
    {
        public static IEnumerable<Target> ToTargets(this XCopyBounceConfiguration config)
        {
            return null;
        }
    }
}
