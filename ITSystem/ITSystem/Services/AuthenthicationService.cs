using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;
using ITSystem.Repositories;

namespace ITSystem.Services
{
    public class AuthenthicationService
    {
        public Consultant LoggedConsultant { get; set; }

        public void Authenticate(string username, string password)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            LoggedConsultant = unitOfWork.ConsultantRepository.GetAll(cons => cons.Username == username && cons.Password == password).FirstOrDefault();
        }
    }
}