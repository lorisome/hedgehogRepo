using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.Page_Objects
{
    class WeatherPage
    {
        private IWebDriver driver;
        public const string Url = "http://localhost:55601/Weather/Weather";

        public WeatherPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        [FindsBy(How = How.Id, Using = "spantag")]
        public IWebElement HighTemp { get; set; }

        [FindsBy(How = How.Id, Using = "theid")]
        public IWebElement CelButton { get; set; }

        [FindsBy(How = How.Id, Using = "stuff")]
        public IWebElement SubmitButton { get; set; }


        public WeatherPage ClickCelcius()
        {
           
            CelButton.Click();
            SubmitButton.Click();

            return new WeatherPage(driver);
        }



    }
}
