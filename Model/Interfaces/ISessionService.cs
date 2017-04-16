using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ISessionService
    {
        bool CreateSession(string username);
        AppUser GetSession();
        void DestroySession();
    }
}
