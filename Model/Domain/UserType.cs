using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }

        public string UserTypeName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }

        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
}
