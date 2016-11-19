using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.Page_Objects
{
    class DetailPage
    {

        private IWebDriver driver;
        public const string Url = "http://localhost:55601/Home/Detail";

        public DetailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        [FindsBy(How = How.Id, Using ="pleasework")]
        public IWebElement WeatherButton { get; set; }


        public WeatherPage NavigateToWeather()
        {

            WeatherButton.Click();

            return new WeatherPage(driver);
        }






    }
}
