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
            //LoggedConsultant = unitOfWork.ConsultantRepository.GetAll(cons => cons.Username == username && cons.Password == password).FirstOrDefault();
        }

        public static void Logout()
        {
            Authenticate(null, null);
        }
    }
}