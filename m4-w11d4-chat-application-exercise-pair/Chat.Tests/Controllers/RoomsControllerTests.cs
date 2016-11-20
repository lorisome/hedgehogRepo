using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chat.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Web.DataAccess;
using Moq;
using Chat.Web.Models;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace Chat.Web.Controllers.Tests
{
    [TestClass()]
    public class RoomsControllerTests
    {
        [TestMethod()]
        public void Index_ReturnsListOfRooms()
        {
            var mockDal = new Mock<IRoomDAL>();
            mockDal.Setup(m => m.GetOpenRooms()).Returns(new List<RoomModel>());
            var controller = new RoomsController(mockDal.Object, null);

            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("Index", (result as ViewResult).ViewName);
            Assert.IsNotNull((result as ViewResult).Model);
        }

        [TestMethod()]
        public void Create_ReturnsCreateView()
        {
            var controller = new RoomsController(null, null);

            var result = controller.Create() as ViewResult;

            Assert.AreEqual("Create", result.ViewName);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod()]
        public void Create_HttpPost_ValidModel_SavesNewRoom_RedirectsToRoomView()
        {
            //Arrange
            var mockDal = new Mock<IRoomDAL>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(m => m["Username"]).Returns("test-user");
            var mockContext = new Mock<HttpContextBase>();
            mockContext.SetupGet(m => m.Session).Returns(mockSession.Object);
            var room = new RoomModel
            {
                Name = "test-room",
                Description = "test description",
            };
            // Set the Id after calling CreateChatRoom on the DAL
            mockDal.Setup(m => m.CreateChatRoom(room)).Callback(() =>
            {
                room.Id = 1;
            }).Returns(room);
            var controller = new RoomsController(mockDal.Object, null);
            controller.ControllerContext = new ControllerContext(mockContext.Object, new RouteData(), controller);

            //Act
            var result = controller.Create(room) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("View", result.RouteValues["action"]);
            Assert.AreEqual("Rooms", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
            mockDal.Verify(m => m.CreateChatRoom(room));
        }

        [TestMethod()]
        public void Create_HttpPost_InValidModel_RedirectsToCreateView()
        {
            //Arrange
            var controller = new RoomsController(null, null);
            controller.ModelState.AddModelError("error", "error");
            var room = new RoomModel
            {
                Name = "test-room"
            };

            //Act
            var result = controller.Create(room) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod()]
        public void JoinRoom_ExistingRoom_LeavesRooms_AddsUsernameToRoom_ReturnToViewAction()
        {
            var mockDal = new Mock<IRoomDAL>();
            mockDal.Setup(m => m.GetChatRoom("test-room")).Returns(new RoomModel() { Id = 1 });
            var controller = new RoomsController(mockDal.Object, null);

            var result = controller.Join("test-room", "test-user") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("View", result.RouteValues["action"]);
            Assert.AreEqual("Rooms", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
            mockDal.Verify(m => m.LeaveChatRooms("test-user"));
            mockDal.Verify(m => m.JoinChatRoom(1, "test-user"));
        }

        [TestMethod()]
        public void JoinRoom_NonExistingRoom_Ignore_ReturnToIndexAction()
        {
            var mockDal = new Mock<IRoomDAL>();
            var controller = new RoomsController(mockDal.Object, null);

            var result = controller.Join("test-room", "test-user") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Rooms", result.RouteValues["controller"]);
        }

        [TestMethod()]
        public void LeaveRoom_ExistingRoom_RemovesUsername_ReturnIndexAction()
        {
            var mockDal = new Mock<IRoomDAL>();            
            var controller = new RoomsController(mockDal.Object, null);

            var result = controller.Leave("test-user") as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Rooms", result.RouteValues["controller"]);           
            mockDal.Verify(m => m.LeaveChatRooms("test-user"));
        }        

        [TestMethod()]
        public void ViewTest_ValidRoom_ReturnsViewAction()
        {
            var mockRoomDal = new Mock<IRoomDAL>();
            var mockMessageDal = new Mock<IMessageDAL>();            
            mockRoomDal.Setup(m => m.GetChatRoom(1)).Returns(new RoomModel() { Id = 1 });
            var controller = new RoomsController(mockRoomDal.Object, mockMessageDal.Object);

            var result = controller.View(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("View", result.ViewName);
            Assert.IsNotNull(result.Model as RoomViewModel);
        }

        [TestMethod]
        public void ViewTest_InvalidRoom_Returns404()
        {
            var mockDal = new Mock<IRoomDAL>();
            var controller = new RoomsController(mockDal.Object, null);

            var result = controller.View(1) as HttpNotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}