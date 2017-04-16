using HRSystem.Services;
using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSystem.Helpers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        private ISessionService _sessionService;
        private AppUser _appUser;

        public CustomActionAttribute()
        {
            _sessionService = DependencyResolver.Current.GetService<SessionService>();
            _appUser = _sessionService.GetSession();
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.OnActionExecuted = "IActionFilter.OnActionExecuted filter called";
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
           //check if the session is active
            //if not then redirect to the login/home
            if (!_appUser.IsLoggedIn)
            {
                filterContext.HttpContext.Response.Redirect("~/Home");
            }
            
        }
    }
}