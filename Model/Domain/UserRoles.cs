using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class UserRoles
    {
        [Key]
        public int UserRoleID { get; set; }

        public int UserID { get; set; }

        public int UserTypeID { get; set; }

        public virtual User User { get; set; }

        public virtual UserType UserType { get; set; }

    }
}
