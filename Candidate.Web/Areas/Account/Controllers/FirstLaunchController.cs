using System.Web.Mvc;
using Candidate.Areas.Account.Models;
using Candidate.Core.Services;

namespace Candidate.Areas.Account.Controllers
{
    public class FirstLaunchController : Controller
    {
        private readonly IUserManagement _userManagement;
        private readonly IAuthentication _authentication;
        private readonly IEnvironment _environment;

        public FirstLaunchController(IUserManagement userManagement, IAuthentication authentication, IEnvironment environment)
        {
            _userManagement = userManagement;
            _authentication = authentication;
            _environment = environment;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (_userManagement.Current() != null)
            {
                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });                
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(NewAccount account)
        {
            if (ModelState.IsValid)
            {
                _userManagement.Create(account.Login, account.NewPassword);
                _authentication.AuthenticateUser(account.Login);
                _environment.Prepare(Server.MapPath("~/App_LocalResources"));

                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });
            }

            return View(account);
        }

    }
}
