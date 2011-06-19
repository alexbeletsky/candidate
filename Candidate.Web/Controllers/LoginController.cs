using System.Web.Mvc;
using TeamViewer.Economic.Demo.Models;

namespace TeamViewer.Economic.Demo.Controllers
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
                return RedirectToAction("index", new { area = "Dashboard", controller = "Dashboard" });
            }

            ModelState.AddModelError("", "Login or password is incorrect.");
            return View("index", model);
        }
    }
}
