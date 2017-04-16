using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class UserPermissions
    {
        [Key]
        public int UserPermissionID { get; set; }

        public int UserTypeID { get; set; }

        public int PermissionID { get; set; }

        public virtual UserType UserType { get; set; }

        public virtual Permissions Permissions { get; set; }

    }
}
