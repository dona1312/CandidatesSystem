using ITSystem.Models;
using ITSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSystem.Services.ModelServices
{
    public class CandidatesService : BaseService<Candidate>
    {
        public CandidatesService() : base() { }

        public List<Candidate> FindCandidates(string searched)
        {
            if (!string.IsNullOrEmpty(searched))
            {
                return new CandidateRepository().GetAll(m => m.FirstName.ToLower().Contains(searched.ToLower()) || m.MiddleName.ToLower().Contains(searched.ToLower()) || m.LastName.ToLower().Contains(searched.ToLower())).ToList();
            }
            return new CandidateRepository().GetAll();
        }
        public IEnumerable<SelectListItem> GetSelectedUsedTechnologies(List<UsedTechnology> usedTech)
        {
            if (usedTech == null)
                usedTech = new List<UsedTechnology>();

            var selectedIds = usedTech.Select(t => t.Id);

            return new UsedTechnologyRepository().GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString(),
                Selected = selectedIds.Contains(t.Id)
            });
        }
        public void SetSelectedUsedTechnologies(Candidate can, string[] usedTechIds)
        {
            if (usedTechIds == null)
                usedTechIds = new string[0];

            can.UsedTechnologies.Clear();
            foreach (UsedTechnology usedTech in new UsedTechnologyRepository().GetAll())
            {
                if (usedTechIds.Contains(usedTech.ToString()))
                {
                    can.UsedTechnologies.Add(usedTech);
                }
            }
        }
        
    } 
}