using System;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Model;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Filters;
using Candidate.Core.Extensions;
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

        [HttpGet, AddViewNameAndHash, ActionName("configure")]
        public ActionResult Configure(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(c => c.Id == id); ;

            return View(configuration.ViewName, configuration);
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

        [HttpGet, AddViewNameAndHash, ActionName("delete")]
        public ActionResult Delete(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(c => c.Id == id);

            return View(configuration);
        }

        [HttpPost, ActionName("delete")]
        public ActionResult Delete(string id, string notUsedJustToOverloadDelete)
        {
            if (ModelState.IsValid)
            {
                _settingsManager.DeleteConfiguration(id);
                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });
            }

            return View();
        }


        [HttpGet, AddViewNameAndHash]
        public ActionResult Pre(string id, Config.ConfigurationType type)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Pre(string id, Pre config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(id, c => c.Pre = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Github(string id)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == id).SingleOrDefault();

            //return View(siteConfiguration.Github);
        }

        [HttpPost]
        public ActionResult Github(string id, Github config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(id, c => c.Github = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Iis(string id)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == id).SingleOrDefault();

            //return View(siteConfiguration.Iis ?? new Iis());
        }

        [HttpPost]
        public ActionResult Iis(string id, Iis config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(id, c => c.Iis = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Solution(string id)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == id).SingleOrDefault();

            //return View(siteConfiguration.Solution ?? new Solution());
        }

        [HttpPost]
        public ActionResult Solution(string id, Solution config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(id, c => c.Solution = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Post(string id)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == id).SingleOrDefault();

            //return View(siteConfiguration.Post);
        }

        [HttpPost]
        public ActionResult Post(string id, Post config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(id, c => c.Post = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }
    }
}
