using System;
using NUnit.Framework;
using HRSystem.Controllers;
using System.Web.Mvc;
using Model.Domain;
using System.Data.Entity;
using Moq;
using HRSystem.Tests.Fakes;

namespace HRSystem.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<DbSet<User>> _mockSet;
        private Mock<HRSystemContext> _mockContext;

        public HomeControllerTests()
        {
            _mockSet = FakeUserLoginSet.GetMockDataSet();
            _mockContext = new Mock<HRSystemContext>();
        }

        //[Test]
        //public void Login_Success()
        //{
        //    var controller = new HomeController();
        //    var data = new Manager
        //    {
        //        Username = "JoeBloggs",
        //        Password = "8be3c943b1609fffbfc51aad666d0a04adf83c9d"
        //    };
        //    var action = controller.Index(data) as ActionResult;
        //    RedirectToRouteResult result = (RedirectToRouteResult)action;
           
        //    Assert.That(result.RouteValues["Controller"], Is.EqualTo("Products"));
        //    Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        //}
    }
}
