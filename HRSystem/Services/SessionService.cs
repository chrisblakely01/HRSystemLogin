using Model;
using Model.Enums;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Services
{
    public class SessionService : ISessionService
    {
        private HRSystemContext _db;

        public SessionService(HRSystemContext db)
        {
            _db = db;
        }

        public SessionService()
        {
            _db = new HRSystemContext();
        }

        public bool CreateSession(string username)
        {
            try
            {
                var data = CreateSessionModel(username);

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Add("UserSessionData", data);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public AppUser GetSession()
        {

            if (HttpContext.Current.Session["UserSessionData"] != null) 
            {
                return (AppUser)HttpContext.Current.Session["UserSessionData"];
            }
            else
            {
                return new AppUser();
            }
        }

        public void DestroySession()
        {
            HttpContext.Current.Session.Clear();
        }

        private AppUser CreateSessionModel(string username)
        {
            var user = _db.User.Where(x => x.Username == username).SingleOrDefault();

            var userIdList = new List<int>();

            foreach(var id in user.UserRoles)
            {
                userIdList.Add(id.UserTypeID);
            }

            return new AppUser
            {
                UserID = user.UserID,
                UserTypes = userIdList,
                Username = user.Username,
                IsLoggedIn = true
            };
            
        }



    }
}