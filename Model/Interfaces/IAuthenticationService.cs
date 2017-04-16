using Model.Domain;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationStatus AuthenticateUser(string username, string password);

        bool CheckUserIsActive(string username);
    }
}