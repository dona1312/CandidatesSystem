using ITSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSystem.Controllers
{
    [AuthenticationFilter]
    public class BaseController : Controller
    {
        
    }
}