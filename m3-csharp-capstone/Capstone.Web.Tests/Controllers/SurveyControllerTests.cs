using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Capstone.Web.Controllers;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class SurveyControllerTests
    {
        [TestMethod]
        public void Survey_Post_valid_data_returns_Survey_result_view()
        {
            Mock<ISurveyDAL> mockDAL = new Mock<ISurveyDAL>();
            mockDAL.Setup(m => m.SaveNewSurvey(It.IsAny<Survey>())).Returns(true);
            SurveyController s = new SurveyController(mockDAL.Object);

            var result = s.SurveyForm(It.IsAny<Survey>()) as RedirectToRouteResult;

            Assert.AreEqual("SurveyResult", result.RouteValues["action"]);


        }
    }
}
