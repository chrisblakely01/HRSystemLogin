using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IUserService
    {
        List<string> GetUserTypes();
        List<string> GetUserPermissions();
        bool ResetPassword(string username, string securityAnswer, string password);
        bool VerifyUsername(string username);
        bool VerifySecurityAnswer(string username, string securityAnswer);
        void UpdatePassword(string username, string password);
    }
}
