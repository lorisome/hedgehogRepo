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
    public class MessagesControllerTests
    {
        [TestMethod()]
        public void NewTest_InvalidModel_ResultsBadRequest()
        {
            var model = new MessageModel
            {
                Message = "test message",
                RoomId = 1,
                Username = "test user"
            };
            var controller = new MessagesController(null, null);
            controller.ModelState.AddModelError("error", "error");

            var result = controller.New(model) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void NewTest_InvalidRoomId_ResultsBadrequest()
        {
            var model = new MessageModel
            {
                Message = "test message",
                RoomId = 1,
                Username = "test user"
            };
            var mockRoomDal = new Mock<IRoomDAL>();
            var controller = new MessagesController(null, mockRoomDal.Object);            

            var result = controller.New(model) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void NewTest_ValidRoom_UserNotMember_ResultsBadRequest()
        {
            var model = new MessageModel
            {
                Message = "test message",
                RoomId = 1,
                Username = "test user"
            };
            var mockRoomDal = new Mock<IRoomDAL>();
            mockRoomDal.Setup(m => m.GetChatRoom(1)).Returns(new RoomModel());
            mockRoomDal.Setup(m => m.IsUserInRoom(1, "test user")).Returns(false);

            var controller = new MessagesController(null, mockRoomDal.Object);

            var result = controller.New(model) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }


        [TestMethod]
        public void NewTest_ValidRoom_ResultsRedirectToViewAction()
        {
            var model = new MessageModel
            {
                Message = "test message",
                RoomId = 1,
                Username = "test user"
            };
            var mockRoomDal = new Mock<IRoomDAL>();
            mockRoomDal.Setup(m => m.GetChatRoom(1)).Returns(new RoomModel());
            mockRoomDal.Setup(m => m.IsUserInRoom(1, "test user")).Returns(true);
            var mockMessageDal = new Mock<IMessageDAL>();

            var controller = new MessagesController(mockMessageDal.Object, mockRoomDal.Object);
            var result = controller.New(model) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("View", result.RouteValues["action"]);
            Assert.AreEqual("Rooms", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);

        }
    }
}