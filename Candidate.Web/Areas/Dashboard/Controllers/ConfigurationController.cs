using System;

namespace Candidate.Areas.Dashboard.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Candidate.Areas.Dashboard.Models;
    using Candidate.Core.Settings;
    using Candidate.Core.Settings.Model;
    using Candidate.Infrustructure.Filters;

    [Authorize]
    public class ConfigurationController : Controller
    {
        private ISettingsManager _settingsManager;

        public ConfigurationController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Index(string jobName)
        {
            return View();
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Pre(string jobName)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //return View(siteConfiguration.Pre);
        }

        [HttpPost]
        public ActionResult Pre(string jobName, Pre config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(jobName, c => c.Pre = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Github(string jobName)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //return View(siteConfiguration.Github);
        }

        [HttpPost]
        public ActionResult Github(string jobName, Github config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(jobName, c => c.Github = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Iis(string jobName)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //return View(siteConfiguration.Iis ?? new Iis());
        }

        [HttpPost]
        public ActionResult Iis(string jobName, Iis config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(jobName, c => c.Iis = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Solution(string jobName)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //return View(siteConfiguration.Solution ?? new Solution());
        }

        [HttpPost]
        public ActionResult Solution(string jobName, Solution config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(jobName, c => c.Solution = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Post(string jobName)
        {
            throw new NotImplementedException();

            //var currentConfiguration = _settingsManager.ReadSettings<ConfigurationsList>();
            //var siteConfiguration = currentConfiguration.Configurations.Where(c => c.Id == jobName).SingleOrDefault();

            //return View(siteConfiguration.Post);
        }

        [HttpPost]
        public ActionResult Post(string jobName, Post config)
        {
            throw new NotImplementedException();

            //if (ModelState.IsValid)
            //{
            //    _settingsManager.SaveSiteConfiguration(jobName, c => c.Post = config);
            //    return Json(new { success = true });
            //}

            //return Json(new { success = false });
        }

        [HttpGet, AddViewNameAndHash]
        public ActionResult Delete(string jobName)
        {
            return View(new DeleteJobModel { JobName = jobName });
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
