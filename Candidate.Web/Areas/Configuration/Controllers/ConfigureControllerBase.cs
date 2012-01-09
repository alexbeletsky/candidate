using System;
using System.Web.Mvc;
using Candidate.Core.Extensions;
using Candidate.Core.Settings;

namespace Candidate.Areas.Configuration.Controllers
{
    public class ConfigureControllerBase : SecuredController
    {
        private readonly ISettingsManager _settingsManager;

        public ConfigureControllerBase(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        protected ActionResult View<T>(string id, string viewName, Func<T, object> property, Action<dynamic> viewBagAction) where T : Core.Configurations.Types.Configuration
        {
            var configuration = _settingsManager.ReadConfiguration<T>(id);

            if (viewBagAction != null)
            {
                viewBagAction(ViewBag);
            }

            return View(viewName, property(configuration));                    
        }

        protected ActionResult View<T>(string id, string viewName, Func<T, object> property) where T : Core.Configurations.Types.Configuration
        {
            return View(id, viewName, property, null);
        }

        protected ActionResult Post<T>(string id, Action<T> update) where T : Core.Configurations.Types.Configuration, new()
        {
            if (ModelState.IsValid)
            {
                _settingsManager.UpdateConfiguration(id, update);
            }

            return RedirectToAction("configure", new { area = "Configuration", controller = "Configure" });
        }
    }
}