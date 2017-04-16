using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Permissions
    {
        [Key]
        public int PermissionID { get; set; }

        public string PermissionName { get; set; }

        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
}
