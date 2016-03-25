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
            AccountLoginVM model = new AccountLoginVM();
            model.RedirectUrl = redirectUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            if (!model.IsRemembered)
                AuthenticationService.AuthenticateConsultant(model.Username, model.Password);
            else
                CookieService.AuthenticateConsultant(model.Username, model.Password);

            if (AuthenticationService.LoggedConsultant != null)
            {
                if (!String.IsNullOrEmpty(model.RedirectUrl))
                {
                    return Redirect(model.RedirectUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationService.Logout();
            return RedirectToAction("Login");
        }
    }
}