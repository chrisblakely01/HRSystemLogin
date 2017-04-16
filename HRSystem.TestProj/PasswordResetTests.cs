using System;
using NUnit.Framework;
using System.Data.Entity;
using Moq;
using HRSystem.Tests.Fakes;
using Model.Domain;
using HRSystem.Services;

namespace HRSystem.TestProj
{
    [TestFixture]

    public class PasswordResetTests
    {
        private Mock<DbSet<User>> _mockSet;
        private Mock<HRSystemContext> _mockContext;

        public PasswordResetTests()
        {
            _mockSet = FakeUserLoginSet.GetMockDataSet();
            _mockContext = new Mock<HRSystemContext>();

        }

        [Test]
        public void Reset_Password_Username_Incorrect()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new UserService(_mockContext.Object);
            var result = service.VerifyUsername("UsernameISwrong");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Reset_Password_Username_Correct()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new UserService(_mockContext.Object);
            var result = service.VerifyUsername("JamesThompson67");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void Security_Answer_Incorrect_Username_Correct()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new UserService(_mockContext.Object);
            var result = service.VerifySecurityAnswer("JamesThompson67", "ThisIsIncorrect");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Security_Answer_Correct_Username_Correct()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new UserService(_mockContext.Object);
            var result = service.VerifySecurityAnswer("JamesThompson67", "dog");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void Security_Answer_Correct_Username_Incorrect()
        {
            _mockContext.Setup(x => x.User).Returns(_mockSet.Object);

            var service = new UserService(_mockContext.Object);
            var result = service.VerifySecurityAnswer("UsernameToFail", "dog");

            Assert.AreEqual(false, result);
        }

    }
    
}
