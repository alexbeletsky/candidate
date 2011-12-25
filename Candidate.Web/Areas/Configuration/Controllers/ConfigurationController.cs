using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Extensions;
using Candidate.Core.Settings;
using Config = Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Configuration.Controllers
{
    [Authorize]
    public class ConfigurationController : Controller
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IConfigurationsFactory _configurationsFactory;

        public ConfigurationController(ISettingsManager settingsManager, IConfigurationsFactory configurationsFactory)
        {
            _settingsManager = settingsManager;
            _configurationsFactory = configurationsFactory;
        }

        [HttpGet, ActionName("add")]
        public ActionResult Add()
        {
            return View(new NewConfigurationModel());
        }

        [HttpPost, ActionName("add")]
        public ActionResult Add(NewConfigurationModel model)
        {
            if (ModelState.IsValid)
            {
                var configuration = _configurationsFactory.CreateConfiguration(
                    model.SelectedType,
                    model.Name.SubstitutePunctuationWithDashes(),
                    model.Name);

                _settingsManager.SaveConfiguration(configuration);

                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });
            }

            return View(model);
        }

        [HttpGet, ActionName("delete")]
        public ActionResult Delete(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(c => c.Id == id);

            return View(configuration);
        }

        [HttpPost, ActionName("delete")]
        public ActionResult DeleteConfiguration(string id)
        {
            if (ModelState.IsValid)
            {
                _settingsManager.DeleteConfiguration(id);
                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });
            }

            return View();
        }
    }
}
