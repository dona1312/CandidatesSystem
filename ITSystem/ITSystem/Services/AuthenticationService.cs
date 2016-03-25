using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;
using ITSystem.Repositories;

namespace ITSystem.Services
{
    public static class AuthenticationService
    {
        public static Consultant LoggedConsultant { get; set; }

        public static void Authenticate(string username, string password)
        {
            ConsultantRepository consultantRepo = new ConsultantRepository();
            LoggedConsultant = consultantRepo.GetAll().FirstOrDefault(c => c.Username == username && c.Password == password);
        }

        public static void Logout()
        {
            Authenticate(null, null);
            //HttpContext.Current.Session[typeof(AuthenticationService).Name] = null;
        }
    }
}