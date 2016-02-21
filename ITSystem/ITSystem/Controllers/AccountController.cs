using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels.Account;
using ITSystem.Services;

namespace ITSystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string redirectUrl)
        {
            if (AuthenticationService.LoggedConsultant != null)
            {
                return RedirectToAction("Index", "Home");
            }

            AccountLoginVM model = new AccountLoginVM();

            if (!String.IsNullOrEmpty(redirectUrl))
            {
                model.RedirectUrl = redirectUrl;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            AuthenticationService.Authenticate(model.Username, model.Password);

            if (AuthenticationService.LoggedConsultant == null)
            {
                ModelState.AddModelError(String.Empty, "Invalid usename or password");
                return View(model);
            }
            else
            {
                return RedirectToAction("List", "Candidates");
            }
        }

        public ActionResult Logout()
        {
            AuthenticationService.Logout();
            return RedirectToAction("Login");
        }
    }
}