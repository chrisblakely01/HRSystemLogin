using Model.Domain;
using Model.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Tests.Fakes
{
    public static class FakeUserLoginSet
    {
        public static Mock<DbSet<User>> GetMockDataSet()
        {
            var data = new List<User>
            {
                new User{UserID=1, Username="TomTom25", Password="8be3c943b1609fffbfc51aad666d0a04adf83c9d", IsActive = true},//Password
                new User{UserID=2, Username="JamesThompson67", Password="b2e98ad6f6eb8508dd6a14cfa704bad7f05f6fb1", IsActive = true, SecurityQuestion = "What is your favourite animal", SecurityAnswer= "dog"},//Password123
                new User{UserID=3, Username="DavidMarshall88", Password="8be3c943b1609fffbfc51aad666d0a04adf83c9d", IsActive = true},//Password
                new User{UserID=4, Username="AshBeck123", Password="b2e98ad6f6eb8508dd6a14cfa704bad7f05f6fb1" , IsActive = true}//Password123
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        
        }

    }
}
