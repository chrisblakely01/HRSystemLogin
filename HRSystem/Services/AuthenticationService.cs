using Model.Enums;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRSystem.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private HRSystemContext _db;

        public AuthenticationService(HRSystemContext db)
        {
            _db = db;
        }

        public AuthenticationService()
        {
            _db = new HRSystemContext();
        }

        public AuthenticationStatus AuthenticateUser(string username, string password)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();

            if(user == null)
                return AuthenticationStatus.USER_NOT_FOUND;

            if (user.Password != password)
                return AuthenticationStatus.INCORRECT_DETAILS;

            if (CheckUserIsActive(username))
            {
                return AuthenticationStatus.LOGGED_IN;
            }
            else
            {
                return AuthenticationStatus.LOCKED_OUT;
            }


        }

        public bool CheckUserIsActive(string username)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();

            return user.IsActive;
        }

    }
}