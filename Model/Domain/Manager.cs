using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Manager : User
    {
        private UserTypeEnum _userType;

        public Manager()
        {
            _userType = UserTypeEnum.MANAGER;
        }
    }
}
