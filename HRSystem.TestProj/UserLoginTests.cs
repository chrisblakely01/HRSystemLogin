using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRSystem;
using HRSystem.Controllers;
using NUnit.Framework;
using Moq;
using HRSystem.Services;
using System.Data.Entity;
using HRSystem.Tests.Fakes;
using Model.Domain;
using Model.Enums;

namespace HRSystem.Tests.Controllers
{
    [TestFixture]
    public class UserLoginTests
    {
        private Mock<DbSet<User>> _mockSet;
        private Mock<HRSystemContext> _mockContext;

        public UserLoginTests()
        { 
            _mockSet = FakeUserLoginSet.GetMockDataSet();
            _mockContext = new Mock<HRSystemContext>();
        }

        [Test]
        public void Correct_Username_And_Password()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new AuthenticationService(_mockContext.Object);
            var result = service.AuthenticateUser("JamesThompson67", "b2e98ad6f6eb8508dd6a14cfa704bad7f05f6fb1");

            Assert.AreEqual(AuthenticationStatus.LOGGED_IN, result);
        }

        [Test]
        public void No_Username_Or_Password_Entered()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new AuthenticationService(_mockContext.Object);
            var result = service.AuthenticateUser(null, null);

            Assert.AreEqual(AuthenticationStatus.USER_NOT_FOUND, result);
        }

        [Test]
        public void Incorrect_Username_And_Password()
        {

            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new AuthenticationService(_mockContext.Object);
            var result = service.AuthenticateUser("JoeBloggs", "8be3c943b1609fffbfc51aad666d0a04adf83c9d");

            Assert.AreEqual(AuthenticationStatus.USER_NOT_FOUND, result);
        }


        [Test]
        public void Correct_Username_Incorrect_Password()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new AuthenticationService(_mockContext.Object);
            var result = service.AuthenticateUser("DavidMarshall88", "PasswordToFail");

            Assert.AreEqual(AuthenticationStatus.INCORRECT_DETAILS, result);
        }

        [Test]
        public void Incorrect_Username_Correct_Password()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new AuthenticationService(_mockContext.Object);
            var result = service.AuthenticateUser("UsernameToFail", "8be3c943b1609fffbfc51aad666d0a04adf83c9d");

            Assert.AreEqual(AuthenticationStatus.USER_NOT_FOUND, result);

        }

        //[Test]
        //public void User_Locked_After_3_Attempts()
        //{
        //    _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

        //    var db = new HRSystemContext();
        //    var username = "LockMeOut";

        //    var service = new LoginService(db);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        service.HandleFailedLogin(username);
        //    }

        //    var user = db.User.Where(x => x.Username == username).SingleOrDefault();

        //    Assert.AreEqual(false, user.IsActive);
        //}
    }
}
