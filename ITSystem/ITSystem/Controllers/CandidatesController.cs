using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels;
using ITSystem.ViewModels.Candidates;
using ITSystem.Repositories;
using ITSystem.Models;

namespace ITSystem.Controllers
{
    public class CandidatesController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Users
        public ActionResult List()
        {
            CandidateListVM model = new CandidateListVM();
            TryUpdateModel(model);
            model.Candidates = unitOfWork.CandidateRepository.GetAll();
            
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            Candidate candidate = new Candidate();
            if (id > 0)
            {
                candidate = unitOfWork.CandidateRepository.GetById(id.Value);
            }

            CandidateEditVM model = new CandidateEditVM();
            model.Id = candidate.Id;
            model.FirstName = candidate.FirstName;
            model.MiddleName = candidate.MiddleName;
            model.LastName = candidate.LastName;
            model.Email = candidate.Email;
            model.ProgrammingLanguages = candidate.ProgrammingLanguages;
            model.UsedTechnologies = candidate.UsedTechnologies;
            model.Notes = candidate.Notes;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Edit(CandidateEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Candidate candidate = new Candidate();

            if (model.Id > 0)
            {
                candidate = unitOfWork.CandidateRepository.GetById(model.Id);
            }

            candidate.Id = model.Id;
            candidate.FirstName = model.FirstName;
            candidate.MiddleName = model.MiddleName;
            candidate.LastName = model.LastName;
            candidate.Email = model.Email;
            candidate.ProgrammingLanguages = model.ProgrammingLanguages;
            candidate.UsedTechnologies = model.UsedTechnologies;
            candidate.Notes = model.Notes;

            unitOfWork.CandidateRepository.Save(candidate);

            return RedirectToAction("List");
        }
    }
}