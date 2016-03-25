using ITSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Services
{
    public static class CookieService
    {
        public static void AuthenticateConsultant(string username, string password)
        {
            ConsultantRepository consultantRepo = new ConsultantRepository();
            AuthenticationService.LoggedConsultant = consultantRepo.GetAll().FirstOrDefault(c => c.Username == username && c.Password == password);

            if (AuthenticationService.LoggedConsultant != null)
            {
                HttpContext.Current.Session["LoggedConsultant"] = AuthenticationService.LoggedConsultant;

                HttpCookie rememberMeCookie = new HttpCookie("rememberMe");
                AuthenticationService.LoggedConsultant.RememberMeHash = Guid.NewGuid().ToString();
                consultantRepo.Save(AuthenticationService.LoggedConsultant);

                rememberMeCookie.Name = AuthenticationService.LoggedConsultant.Username;
                rememberMeCookie.Value = AuthenticationService.LoggedConsultant.RememberMeHash;
                rememberMeCookie.Expires.AddDays(7);
                HttpContext.Current.Response.Cookies.Add(rememberMeCookie);
            }
        }

        public static void AuthenticateCookie()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies["rememberMe"];
            ConsultantRepository consultantRepo = new ConsultantRepository();
            AuthenticationService.LoggedConsultant = consultantRepo.GetAll().FirstOrDefault(c => c.RememberMeHash == cookie.Value);
        }
    }
}