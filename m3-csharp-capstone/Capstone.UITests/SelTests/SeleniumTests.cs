using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Capstone.UITests.Page_Objects;

namespace Capstone.UITests.SelTests
{
    [TestClass]
    public class SeleniumTests
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }



        [TestMethod]
        public void FindHighTempOnWeather()
        {
            IndexPage page = new IndexPage(driver);
            page.Navigate();
            DetailPage detPage = page.NavigateToDetail();
            WeatherPage wetPage = detPage.NavigateToWeather();
            Assert.AreEqual("62", wetPage.HighTemp.Text);



        }


        [TestMethod]
        public void SeeifTheTempChangedToCelcius()
        {
            IndexPage page = new IndexPage(driver);
            page.Navigate();
            DetailPage detPage = page.NavigateToDetail();
            WeatherPage wetPage = detPage.NavigateToWeather();
            Assert.AreEqual("62", wetPage.HighTemp.Text);

            WeatherPage newwetPage = wetPage.ClickCelcius();

            Assert.AreEqual("17", newwetPage.HighTemp.Text);




        }
    }
}
