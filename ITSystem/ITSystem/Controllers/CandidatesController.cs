using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels;
using ITSystem.ViewModels.Candidates;
using ITSystem.Services.ModelServices;
using ITSystem.Models;

namespace ITSystem.Controllers
{
    public class CandidatesController : Controller
    {
        CandidatesService candidatesService = new CandidatesService();

        public ActionResult List()
        {
            CandidateListVM model = new CandidateListVM();
            model.Candidates = candidatesService.GetAll();

            // find candidate
            TryUpdateModel(model);
            model.Candidates = candidatesService.FindCandidates(model.Search);

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CandidateEditVM model = new CandidateEditVM();
            Candidate candidate;

            if (!id.HasValue)
            {
                candidate = new Candidate();
            }
            else
            {
                candidate = candidatesService.GetById(id.Value);
                if (candidate == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.Id = candidate.Id;
            model.FirstName = candidate.FirstName;
            model.MiddleName = candidate.MiddleName;
            model.LastName = candidate.LastName;
            model.Skills = candidate.Skills;
            model.Email = candidate.Email;
            model.Notes = candidate.Notes;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CandidateEditVM model = new CandidateEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Candidate candidate;
            if (model.Id == 0)
            {
                candidate = new Candidate();
            }
            else
            {
                candidate = candidatesService.GetById(model.Id);
                if (candidate == null)
                {
                    return RedirectToAction("List");
                }
            }

            candidate.Id = model.Id;
            candidate.FirstName = model.FirstName;
            candidate.MiddleName = model.MiddleName;
            candidate.LastName = model.LastName;
            candidate.Email = model.Email;
            candidate.Skills = model.Skills;
            candidate.Notes = model.Notes;

            candidatesService.Save(candidate);
            return RedirectToAction("List");
        }

        public ActionResult Details(int? id)
        {
            CandidateEditVM model = new CandidateEditVM();
            TryUpdateModel(model);
            Candidate candidate;

            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }
            else
            {
                candidate = candidatesService.GetById(id.Value);
                if (candidate == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.Id = candidate.Id;
            model.FirstName = candidate.FirstName;
            model.MiddleName = candidate.MiddleName;
            model.LastName = candidate.LastName;
            model.Email = candidate.Email;
            model.Skills = candidatesService.GetCandidateSkills(model.Id);
            model.Notes = candidate.Notes;
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            Candidate candidate;
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }
            else
            {
                candidate = candidatesService.GetById(id.Value);
                if (candidate == null)
                {
                    return RedirectToAction("List");
                }
            }
            
            candidatesService.Delete(candidate);
            return RedirectToAction("List");
        }
    }
}