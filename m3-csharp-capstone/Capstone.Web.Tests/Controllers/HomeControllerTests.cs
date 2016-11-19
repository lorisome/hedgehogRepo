using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Moq;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            //Arrange
            Mock<IParkDAL> mockDAL = new Mock<IParkDAL>();
            mockDAL.Setup(m => m.GetAllParks()).Returns(new List<Models.Park>());
            HomeController controller = new HomeController(mockDAL.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}