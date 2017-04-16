using Model.Enums;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Employee : User
    {
        private UserTypeEnum _userType;

        public Employee()
        {
            _userType = UserTypeEnum.EMPLOYEE;
        }
    }
}
