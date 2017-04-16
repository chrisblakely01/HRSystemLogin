using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ILoginService
    {
        AuthenticationStatus Login(string username, string password);
        AuthenticationStatus HandleFailedLogin(string username);
    }
}
