using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSystem.Services;

namespace ITSystem.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Response.Cookies["rememberMe"] != null)
            {
                CookieService.AuthenticateCookie();
            }

            if (AuthenticationService.LoggedConsultant == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Account/Login?RedirectUrl=" + filterContext.HttpContext.Request.Url);
                filterContext.Result = new EmptyResult();
            }
        }
    }
}