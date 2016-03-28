using ITSystem.Enums;
using ITSystem.Models;
using ITSystem.Services;
using ITSystem.Services.ModelServices;
using ITSystem.ViewModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ITSystem.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            EmailSendVM model = new EmailSendVM();
            CandidatesService canService = new CandidatesService();
            model.Recievers = canService.GetAll();
            TryUpdateModel(model);

            if (!String.IsNullOrEmpty(model.Search))
            {
                switch (model.SearchType)
                {
                    case SearchEnum.UsedTechnology:
                        EmailService.Recievers = model.Recievers.Where(c => c.UsedTechnologies
                                                            .Any(t => t.Name.ToLower().Contains(model.Search.ToLower()))).ToList();
                        break;
                    case SearchEnum.ProgrammingLanguage:
                        EmailService.Recievers = model.Recievers.Where(c => c.ProgrammingLanguages
                                                            .Any(p => p.Name.ToLower().Contains(model.Search.ToLower()))).ToList();
                        break;
                    case SearchEnum.Name:
                    default:
                        EmailService.Recievers = model.Recievers.Where(c => c.FirstName.ToLower().Contains(model.Search.ToLower()) || c.LastName.ToLower().Contains(model.Search.ToLower())).ToList();
                        break;
                }
            }
            return View(model);
        }
        public ActionResult Set()
        {
            EmailSendVM model = new EmailSendVM();
            return View(model);

        }
        public ActionResult Fill()
        {
            EmailSendVM model = new EmailSendVM();
            TryUpdateModel(model);
            EmailService.Subject = model.Subject;
            EmailService.Body = model.Body;
            EmailService.Pass = model.Password;

            return RedirectToAction("SendMail", "Email");

        }
        public ActionResult SendMail()
        {
            EmailService.SendEmail();
            // System.Threading.Tasks.Task.Run(() => EmailService.SendEmail(model.Recievers));
            return RedirectToAction("Index", "Home");
        }
    }
}