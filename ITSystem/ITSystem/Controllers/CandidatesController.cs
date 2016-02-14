using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels;
using ITSystem.ViewModels.Candidates;
using ITSystem.Repositories;

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
    }
}