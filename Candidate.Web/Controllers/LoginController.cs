using System.Web.Mvc;
using Candidate.Models;
using System.Web.Security;
using Candidate.Infrustructure.Authentication;
using System;

namespace Candidate.Controllers {
    public class LoginController : Controller {
        private IAuthentication _authentication;

        public LoginController(IAuthentication  authentication) {
            _authentication = authentication;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model) {
            if (_authentication.ValidateUser(model.Login, model.Password)) {
                _authentication.AuthenticateUser(model.Login);
                return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
            }

            ModelState.AddModelError("", "Login or password is incorrect.");
            return View("Index", model);
        }
    }
}
