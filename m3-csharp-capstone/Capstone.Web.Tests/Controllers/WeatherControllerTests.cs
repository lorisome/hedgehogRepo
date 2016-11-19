using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using Moq;
using Capstone.Web.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void WeatherAction_returns_WeatherView()
        {

            var mockContext = new Mock<HttpContextBase>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(m => m["parkID"]).Returns("CVNP");
            mockSession.SetupGet(m => m["keepTempType"]).Returns("F");

            mockContext.Setup(ctx => ctx.Session).Returns(mockSession.Object);

            //mockContext.Setup(m => m.SetSessionStateBehavior())
            Mock<IWeatherDAL> mockDAL = new Mock<IWeatherDAL>();
            Models.Weather w = new Models.Weather();
            w.ParkCode = "CVNP";
            List<Models.Weather> fakeList = new List<Models.Weather>();

            fakeList.Add(w);
            mockDAL.Setup(m => m.Get5DaysOfWeather("CVNP")).Returns(fakeList);

            WeatherController c = new WeatherController(mockDAL.Object);
            c.ControllerContext = new ControllerContext(mockContext.Object, new RouteData(), c);

            var result = c.Weather("CVNP");

            Assert.IsTrue(result is ViewResult);
            var view = result as ViewResult;
            Assert.AreEqual("Weather", view.ViewName);
            Assert.IsNotNull(view.Model);

        }
    }
}
