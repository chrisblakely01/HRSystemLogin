using HRSystem;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem
{
    public class HRSystemInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<HRSystemContext>
    {
        protected override void Seed(HRSystemContext context)
        {
        //    var userTypes = new List<UserType>
        //    {
        //        new UserType { UserTypeName = "ADMINISTRATOR"},
        //        new UserType { UserTypeName = "MANAGER"},
        //        new UserType { UserTypeName = "EMPLOYEE"}
        //    };

        //    userTypes.ForEach(s => context.UserType.Add(s));
        //    context.SaveChanges();

        //    var user = new List<User>
        //    {
        //        new User {FirstName = "Joe", LastName = "Bloggs", Username = "JoeBloggs", Email = "JoeBloggs@system.com", Password ="8be3c943b1609fffbfc51aad666d0a04adf83c9d", SecurityQuestion = "what is your favourite animal", SecurityAnswer = "dog", LoginAttempts=0, IsActive = true},
        //        new User {FirstName = "Locked", LastName = "Out", Username = "LockMeOut", Email = "JoeBloggs@system.com", Password ="8be3c943b1609fffbfc51aad666d0a04adf83c9d", SecurityQuestion = "what is your favourite animal", SecurityAnswer = "dog", LoginAttempts=0, IsActive = true}
        //    };

        //    user.ForEach(s => context.User.Add(s));
        //    context.SaveChanges();

        //    var userRoles = new List<UserRoles>
        //    {
        //        new UserRoles{UserID = 1, UserRoleID = 1},
        //        new UserRoles{UserID = 1, UserRoleID = 3},
        //        new UserRoles{UserID = 2, UserRoleID = },
        //    };

        //    userRoles.ForEach(s => context.UserRoles.Add(s));
        //    context.SaveChanges();
        }
    }
}
