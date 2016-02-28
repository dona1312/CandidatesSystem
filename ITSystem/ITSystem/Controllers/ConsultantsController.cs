﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.ViewModels.Consultants;
using ITSystem.Services.ModelServices;
using ITSystem.Models;

namespace ITSystem.Controllers
{
    public class ConsultantsController : Controller
    {
        ConsultantService consultantService = new ConsultantService();

        public ActionResult List()
        {
            ConsultantListVM model = new ConsultantListVM();
            model.Consultants = consultantService.GetAll();

            // find consultant
            TryUpdateModel(model);
            model.Consultants = consultantService.FindConsultants(model.Search);

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            ConsultantEditVM model = new ConsultantEditVM();
            Consultant consultant;

            if (!id.HasValue)
            {
                consultant = new Consultant();
            }
            else
            {
                consultant = consultantService.GetById(id.Value);
                if (consultant == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.Id = consultant.Id;
            model.Username = consultant.Username;
            model.Password = consultant.Password;
            model.FirstName = consultant.FirstName;
            model.LastName = consultant.LastName;
            model.Email = consultant.Email;
            model.Rank = consultant.Rank;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            ConsultantEditVM model = new ConsultantEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Consultant consultant;
            if (model.Id == 0)
            {
                consultant = new Consultant();
            }
            else
            {
                consultant = consultantService.GetById(model.Id);
                if (consultant == null)
                {
                    return RedirectToAction("List");
                }
            }

            consultant.Id = model.Id;
            consultant.Username = model.Username;
            consultant.Password = model.Password;
            consultant.FirstName = model.FirstName;
            consultant.LastName = model.LastName;
            consultant.Email = model.Email;
            consultant.Rank = model.Rank;

            consultantService.Save(consultant);
            return RedirectToAction("List");
        }

        public ActionResult Details(int? id)
        {
            ConsultantEditVM model = new ConsultantEditVM();
            Consultant consultant;

            if (!id.HasValue)
            {
                consultant = new Consultant();
            }
            else
            {
                consultant = consultantService.GetById(id.Value);
                if (consultant == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.Id = consultant.Id;
            model.Username = consultant.Username;
            model.Password = consultant.Password;
            model.FirstName = consultant.FirstName;
            model.LastName = consultant.LastName;
            model.Email = consultant.Email;
            model.Rank = consultant.Rank;
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            Consultant consultant;
            if (!id.HasValue)
            {
                consultant = new Consultant();
            }
            else
            {
                consultant = consultantService.GetById(id.Value);
                if (consultant == null)
                {
                    return RedirectToAction("List");
                }
            }

            consultantService.Delete(consultant);
            return RedirectToAction("List");
        }
    }
}