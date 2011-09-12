using System.Web.Mvc;
using Candidate.Models;
using System.Web.Security;

namespace Candidate.Controllers {
    public class LoginController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model) {
            if (Membership.ValidateUser(model.Login, model.Password)) {
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
            }

            ModelState.AddModelError("", "Login or password is incorrect.");
            return View("Index", model);
        }
    }
}
