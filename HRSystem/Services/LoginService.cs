using HRSystem.Helpers;
using Model.Enums;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HRSystem.Services
{
    public class LoginService : ILoginService
    {
        private HRSystemContext _db;

        private IAuthenticationService _authenticationService;
        private ISessionService _sessionService;

        public LoginService(HRSystemContext db, IAuthenticationService authentication, ISessionService session)
        {
            _db = db;
            _authenticationService = authentication;
            _sessionService = session;
        }

        public LoginService(HRSystemContext db)
        {
            _db = db;
        }
        
        public AuthenticationStatus Login(string username, string password)
        {
            var isAuthenticated = _authenticationService.AuthenticateUser(username, EncryptPassword.Encode(password));

            if (isAuthenticated == AuthenticationStatus.INCORRECT_DETAILS)
            {
                isAuthenticated = HandleFailedLogin(username);
            }
            else if (isAuthenticated == AuthenticationStatus.LOGGED_IN)
            {
                CompleteLogin(username);
                CreateSession(username);
            }
            
            return isAuthenticated;
        }

        public AuthenticationStatus HandleFailedLogin(string username)
        {
            AuthenticationStatus result;

            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();
            
            var failedCount = (user.LoginAttempts + 1);
            user.LoginAttempts = failedCount;

            if (failedCount >= 3)
            {
                user.IsActive = false;
                result = AuthenticationStatus.LOCKED_OUT;
            }
            else
            {
                result = AuthenticationStatus.INCORRECT_DETAILS;
            }

            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();

            return result;
        }

        public void CompleteLogin(string username)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();
            user.LoginAttempts = 0;
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        }

        private void CreateSession(string username)
        {
            _sessionService.CreateSession(username);
        }
    }
}