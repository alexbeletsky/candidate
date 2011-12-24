using System;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Filters;

namespace Candidate.Areas.Dashboard.Controllers
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

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Index(string id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new NewConfigurationModel());
        }

        [HttpPost]
        public ActionResult Add(NewConfigurationModel model)
        {
            if (ModelState.IsValid)
            {
                var configuration = _configurationsFactory.CreateConfiguration(
                    model.SelectedType,
                    SubstitutePunctuationWithDashes(model.Name),
                    model.Name);

                _settingsManager.SaveConfiguration(configuration);

                return RedirectToAction("Index", new { controller = "Dashboard" });
            }

            return View(model);
        }

        // TODO: ABE move to extension method
        private string SubstitutePunctuationWithDashes(string title)
        {
            var titleWithoutPunctuation = new string(title.Where(c => !char.IsPunctuation(c)).ToArray());
            return titleWithoutPunctuation.ToLower().Trim().Replace(" ", "-");
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Pre(string id)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == id).SingleOrDefault();

            //return View(siteConfiguration.Pre);
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

        [HttpGet, AddViewNameAndHash]
        public ActionResult Delete(string id)
        {
            return View(new DeleteJobModel { JobName = id });
        }

        [HttpPost]
        public ActionResult Delete(DeleteJobModel deleteJob)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.DeleteSiteConfiguration(deleteJob.Id);
            //    return RedirectToAction("Index", "Dashboard");
            //}

            //return View(deleteJob);
        }


    }
}
