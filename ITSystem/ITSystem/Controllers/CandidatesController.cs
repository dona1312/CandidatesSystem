using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels;
using ITSystem.ViewModels.Candidates;
using ITSystem.Services.ModelServices;
using ITSystem.Models;
using ITSystem.Enums;

using ITSystem.Repositories;

namespace ITSystem.Controllers
{
    public class CandidatesController : BaseController
    {
        public ActionResult List()
        {
            CandidatesService candidatesService = new CandidatesService();
            CandidateListVM model = new CandidateListVM();
            model.Candidates = candidatesService.GetAll();
            TryUpdateModel(model);

            // search
            if (!String.IsNullOrEmpty(model.Search))
            {
                switch (model.SearchType)
                {
                    case SearchEnum.UsedTechnology:
                        model.Candidates = model.Candidates.Where(c => c.UsedTechnologies
                                                            .Any(t => t.Name.ToLower().Contains(model.Search.ToLower()))).ToList();
                        break;
                    case SearchEnum.ProgrammingLanguage:
                        model.Candidates = model.Candidates.Where(c => c.ProgrammingLanguages
                                                            .Any(p => p.Name.ToLower().Contains(model.Search.ToLower()))).ToList();
                        break;
                    case SearchEnum.Name:
                    default:
                        model.Candidates = model.Candidates.Where(c => c.FirstName.ToLower().Contains(model.Search.ToLower()) || c.LastName.ToLower().Contains(model.Search.ToLower())).ToList();
                        break;
                }
            }

            // sort
            switch (model.SortOrder)
            {
                case "lname_asc":
                    model.Candidates = model.Candidates.OrderBy(c => c.LastName).ToList();
                    break;
                case "lname_desc":
                    model.Candidates = model.Candidates.OrderByDescending(c => c.LastName).ToList();
                    break;
                case "fname_desc":
                    model.Candidates = model.Candidates.OrderByDescending(c => c.FirstName).ToList();
                    break;
                case "fname_asc":
                default:
                    model.Candidates = model.Candidates.OrderBy(c => c.FirstName).ToList();
                    break;
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CandidatesService candidatesService = new CandidatesService();
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
            model.Email = candidate.Email;
            model.Notes = candidate.Notes;
            model.UsedTechnologies = candidatesService.GetSelectedUsedTechnologies(candidate.UsedTechnologies);
            model.ProgrammingLanguages = candidatesService.GetSelectedProgrammingLanguages(candidate.ProgrammingLanguages);
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CandidatesService candidatesService = new CandidatesService();
            CandidateEditVM model = new CandidateEditVM();
            TryUpdateModel(model);

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

            if (!ModelState.IsValid)
            {
                model.UsedTechnologies = candidatesService.GetSelectedUsedTechnologies(candidate.UsedTechnologies);
                model.ProgrammingLanguages = candidatesService.GetSelectedProgrammingLanguages(candidate.ProgrammingLanguages);
                return View(model);
            }

            candidate.Id = model.Id;
            candidate.FirstName = model.FirstName;
            candidate.MiddleName = model.MiddleName;
            candidate.LastName = model.LastName;
            candidate.Email = model.Email;
            candidate.Notes = model.Notes;
            candidatesService.SetSelectedUsedTechnologies(candidate, model.SelectedUsedTechnologies);
            candidatesService.SetSelectedProgrammingLanguages(candidate, model.SelectedProgrammingLanguages);

            candidatesService.Save(candidate);
            return RedirectToAction("List");
        }

        public ActionResult Details(int? id)
        {
            CandidatesService candidatesService = new CandidatesService();
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
            model.Notes = candidate.Notes;
            model.UsedTechnologies = candidatesService.GetSelectedUsedTechnologies(candidate.UsedTechnologies);
            model.ProgrammingLanguages = candidatesService.GetSelectedProgrammingLanguages(candidate.ProgrammingLanguages);         
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            CandidatesService candidatesService = new CandidatesService();
            candidatesService.Delete(id.Value);
            return RedirectToAction("List");
        }
    }
}