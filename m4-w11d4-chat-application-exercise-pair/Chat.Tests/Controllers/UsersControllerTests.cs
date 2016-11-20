using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chat.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Chat.Web.DataAccess;
using Chat.Web.Models;
using System.Web.Mvc;
using System.Web;

namespace Chat.Web.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        [TestMethod]
        public void RegisterTest_HttpPost_ModelError_ReturnsRegisterView()
        {
            var mock = new Mock<IUserDAL>();
            var controller = new UsersController(mock.Object);
            controller.ModelState.AddModelError("error", "error");
            var model = new UserModel()
            {
                Username = "username",
                Password = "password"
            };

            //Arrange
            var result = controller.Register(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("Register", (result as ViewResult).ViewName);
        }

        [TestMethod]
        public void RegisterTest_ValidModel_ReturnsRoomsActions()
        {
            //Arrange
            var mockDal = new Mock<IUserDAL>();
            mockDal.Setup(m => m.CreateUser(It.IsAny<UserModel>())).Returns(new UserModel());
            var mockSession = new Mock<HttpSessionStateBase>();
            var mockContext = new Mock<HttpContextBase>();
            mockContext.SetupGet(m => m.Session).Returns(mockSession.Object);
            var controller = new UsersController(mockDal.Object);
            controller.ControllerContext = new ControllerContext(mockContext.Object, new System.Web.Routing.RouteData(), controller);

            var model = new UserModel()
            {
                Username = "username",
                Password = "password"
            };

            //Act
            var result = controller.Register(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is RedirectToRouteResult);
            Assert.AreEqual("Login", (result as RedirectToRouteResult).RouteValues["action"]);
            Assert.AreEqual("Users", (result as RedirectToRouteResult).RouteValues["controller"]);
        }


        [TestMethod()]
        public void LoginTest_HttpPost_ModelError_ReturnsLoginView()
        {
            var mock = new Mock<IUserDAL>();
            var controller = new UsersController(mock.Object);
            controller.ModelState.AddModelError("error", "errro");
            var model = new UserModel()
            {
                Username = "username",
                Password = "password"
            };

            var result = controller.Login(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("Login", (result as ViewResult).ViewName);
        }

        [TestMethod()]
        public void LoginTest_HttpPost_InvalidUserId_ReturnsLoginView()
        {
            var mock = new Mock<IUserDAL>();
            mock.Setup(m => m.GetUser("invalid-username", "invalid-password")).Returns<object>(null);
            var controller = new UsersController(mock.Object);
            var model = new UserModel()
            {
                Username = "invalid-username",
                Password = "invalid-password"
            };

            var result = controller.Login(model);

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("Login", (result as ViewResult).ViewName);
        }

        [TestMethod()]
        public void LoginTest_HttpPost_ValidUserId_ReturnsRoomsAction()
        {
            //Arrange
            var mockDal = new Mock<IUserDAL>();
            mockDal.Setup(m => m.GetUser("username", "password")).Returns(new UserModel());

            var mockSession = new Mock<HttpSessionStateBase>();
            var mockContext = new Mock<HttpContextBase>();
            mockContext.SetupGet(m => m.Session).Returns(mockSession.Object);
            var controller = new UsersController(mockDal.Object);
            controller.ControllerContext = new ControllerContext(mockContext.Object, new System.Web.Routing.RouteData(), controller);

            var model = new UserModel()
            {
                Username = "username",
                Password = "password"
            };

            //Act
            var result = controller.Login(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is RedirectToRouteResult);
            Assert.AreEqual("Index", (result as RedirectToRouteResult).RouteValues["action"]);
            Assert.AreEqual("Rooms", (result as RedirectToRouteResult).RouteValues["controller"]);
        }
    }
}