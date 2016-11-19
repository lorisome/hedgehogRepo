using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.UITests.Page_Objects
{
    class IndexPage
    {


        private IWebDriver driver;
        public const string Url = "http://localhost:55601/Home/Index";

        public IndexPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }


        [FindsBy(How = How.ClassName, Using = "tilepic")]
        public IWebElement PictureClick { get; set; }


        public DetailPage NavigateToDetail()
        {
            
            PictureClick.Click();

            return new DetailPage(driver);
        }



    }
}
