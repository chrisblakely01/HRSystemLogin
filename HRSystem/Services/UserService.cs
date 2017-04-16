using HRSystem.Helpers;
using HRSystem.ViewModels;
using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRSystem.Services
{
    public class UserService : IUserService
    {
        private HRSystemContext _db;

        private AppUser _appUser;

        public UserService(ISessionService sessionService)
        {
            _db = new HRSystemContext();
            _appUser = sessionService.GetSession();
        }
        public UserService(HRSystemContext db)
        {
            _db = db;
        }

        public List<string> GetUserTypes()
        {
           return _db.UserRoles.Where(x => _appUser.UserTypes.Contains(x.UserTypeID)).Select(x => x.UserType.UserTypeName).Distinct().ToList();
        
        }

        public List<string> GetUserPermissions()
        {
            var permissions = _db.UserPermissions.Where(x => _appUser.UserTypes.Contains(x.UserTypeID)).Select(x => x.Permissions.PermissionName).ToList();

            return permissions;
        }

        public bool ResetPassword(string username, string securityAnswer, string password)
        {
            if (!VerifyUsername(username))
                return false;

            if (!VerifySecurityAnswer(username, securityAnswer))
                return false;

            UpdatePassword(username, password);
            return true;
        }

        public bool VerifyUsername(string username)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerifySecurityAnswer(string username, string securityAnswer)
        {
            var user = _db.User.Where(x => x.Username == username && x.SecurityAnswer == securityAnswer).SingleOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void UpdatePassword(string username, string password)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();

            user.Password = EncryptPassword.Encode(password);
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
        
        }

    }
}