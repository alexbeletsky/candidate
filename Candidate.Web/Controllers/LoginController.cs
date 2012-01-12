using System.Web.Mvc;
using Candidate.Core.Services;
using Candidate.Models;

namespace Candidate.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserManagement _userManagement;
        private readonly IAuthentication _authentication;

        public LoginController(IUserManagement userManagement, IAuthentication authentication)
        {
            _userManagement = userManagement;
            _authentication = authentication;
        }

        public ActionResult Index()
        {
            if (_userManagement.Current() == null)
            {
                return RedirectToAction("index", new {area = "account", controller = "firstlaunch"});
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (_authentication.ValidateUser(model.Login, model.Password))
            {
                _authentication.AuthenticateUser(model.Login);
                return RedirectToAction("index", new { area = "dashboard", controller = "dashboard" });
            }

            ModelState.AddModelError("", "Login or password is incorrect.");
            return View("index", model);
        }
    }
}
