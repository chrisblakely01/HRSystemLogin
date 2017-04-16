using Model.Domain;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppUser
    {
        public int UserID { get; set; }

        public List<int> UserTypes { get; set; }

        public string Username { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
