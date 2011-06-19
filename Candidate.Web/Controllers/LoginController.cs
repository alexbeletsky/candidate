using System.Web.Mvc;
using Candidate.Models;

namespace Candidate.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.Login == "alexander.beletsky" && model.Password == "111111")
            {
                return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
            }

            ModelState.AddModelError("", "Login or password is incorrect.");
            return View("Index", model);
        }
    }
}
