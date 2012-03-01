using System;
using System.Web.Mvc;
using Candidate.Areas.Account.Models;
using Candidate.Core.Services;
using Candidate.Core.Settings;

namespace Candidate.Areas.Account.Controllers
{
    public class AccountController : SecuredController
    {
        private readonly IUserManagement _userManagement;

        public AccountController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = _userManagement.Current();
            var model = new NewAccount
            {
                Login = user.Login
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NewAccount model)
        {
            if (ModelState.IsValid)
            {
                _userManagement.Create(model.Login, model.NewPassword);
            }

            return View(model);
        }

    }
}
