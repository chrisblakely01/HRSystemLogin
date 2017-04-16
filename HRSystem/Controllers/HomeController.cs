using HRSystem.Helpers;
using HRSystem.Services;
using HRSystem.ViewModels;
using Model;
using Model.Domain;
using Model.Enums;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSystem.Controllers
{
    public class HomeController : Controller
    {
        private AppUser _appUser;
        private ILoginService _loginService;
        private IUserService _userService;
        private ISessionService  _sessionService;
        public HomeController(ISessionService sessionService, ILoginService loginService, IUserService userService)
        {
            _appUser = sessionService.GetSession();
            _loginService = loginService;
            _userService = userService;
            _sessionService = sessionService;
        }

        public ActionResult Index()
        {
            if (_appUser.IsLoggedIn)
            {
                return RedirectToAction("Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authenticatedStatus = _loginService.Login(model.Username, model.Password);

                switch (authenticatedStatus)
                { 
                    case AuthenticationStatus.LOGGED_IN:
                        return RedirectToAction("Home");
                    case AuthenticationStatus.LOCKED_OUT:
                        ViewBag.LoginMessage = "Account Locked";
                        break;
                    case AuthenticationStatus.INCORRECT_DETAILS:
                        ViewBag.LoginMessage = "Incorrect Credentials";
                        break;
                    case AuthenticationStatus.USER_NOT_FOUND:
                        ViewBag.LoginMessage = "Incorrect Credentials";
                        break;
                }
            }

            return View();
        }

        [CustomActionAttribute]
        public ActionResult Home()
        {
            var permissions = _userService.GetUserPermissions();
            var userTypes = _userService.GetUserTypes();

            var model = new HomeViewModel
            {
                Username = _appUser.Username,
                UserPermissions = string.Join(",", permissions),
                UserTypes = string.Join(",", userTypes)
            };

            return View(model);
        }

        public ActionResult ResetPassword()
        {
            if (_appUser.IsLoggedIn)
                return RedirectToAction("Home");

            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.ResetPassword(model.Username, model.SecurityAnswer, model.NewPassword);

                if (result)
                    ViewBag.ResetPasswordMessage = "Password successfully changed";
                else
                    ViewBag.ResetPasswordMessage = "Security details do not match";
            }
            return View(model);
        
        }

        public ActionResult LogOut()
        {
            _sessionService.DestroySession();

            return RedirectToAction("index");
        }

    }
}