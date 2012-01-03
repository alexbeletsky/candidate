using System;
using System.Web.Mvc;
using Candidate.Core.Settings;

namespace Candidate.Areas.Configuration.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly ISettingsManager _settingsManager;

        public ControllerBase(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        protected ActionResult View<T>(string id, string viewName, Func<T, object> property) where T : Core.Model.Configurations.Configuration
        {
            var configuration = _settingsManager.ReadConfiguration<T>(id);
            return View(viewName, property(configuration));
        }

        protected ActionResult Post<T>(string id, Action<T> update) where T : Core.Model.Configurations.Configuration, new()
        {
            if (ModelState.IsValid)
            {
                _settingsManager.UpdateConfiguration(id, update);
            }

            return RedirectToAction("configure", new { area = "Configuration", controller = "Configure" });
        }
    }
}