using Model;
using Model.Domain;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRSystem.Services
{
    public class PermissionService : IPermissionService
    {
        private HRSystemContext _db;
        private ISessionService _sessionService;
        private AppUser _appUser;

        public PermissionService(ISessionService sessionService)
        {
            _db = new HRSystemContext();
            _sessionService = sessionService;
            _appUser = sessionService.GetSession();
        }


    }
}