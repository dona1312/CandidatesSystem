using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.Services;
using ITSystem.ViewModels;
using ITSystem.ViewModels.Account;

namespace ITSystem.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}