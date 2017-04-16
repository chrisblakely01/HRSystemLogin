using HRSystem.Services;
using HRSystem.Tests.Fakes;
using Model.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Tests.Controllers
{
    [TestFixture]
    public class SessionServiceTests
    {
        private Mock<DbSet<User>> _mockSet;
        private Mock<HRSystemContext> _mockContext;
        public SessionServiceTests()
        {
            _mockContext = new Mock<HRSystemContext>();
        }

        //[Test]
        //public void Session_Created()
        //{
        //    _mockContext.Setup(x => x.User).Returns(_mockSet.Object);
        //    _mockSet = FakeUserLoginSet.GetMockDataSet();

        //    var service = new WebSession(_mockContext.Object);
        //    var result = service.CreateSession("TomTom25");

        //    Assert.AreEqual(true, result);
        //}
    }
}
