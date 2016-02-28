using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;
using ITSystem.Repositories;

namespace ITSystem.Services.ModelServices
{
    public class ConsultantService : BaseService<Consultant>
    {
        public ConsultantService() : base() { }

        public List<Consultant> FindConsultants(string searched)
        {
            if (!string.IsNullOrEmpty(searched))
            {
                return new ConsultantRepository().GetAll(c => c.Username.ToLower().Contains(searched.ToLower()) || c.FirstName.ToLower().Contains(searched.ToLower()) || c.LastName.ToLower().Contains(searched.ToLower()));
            }
            return new ConsultantRepository().GetAll();
        }
    }
}