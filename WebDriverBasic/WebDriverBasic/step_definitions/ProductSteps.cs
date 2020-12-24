using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace WebDriverFramework.step_definitions
{
    [Binding]
    class ProductSteps
    {
        public int index;
        private IWebDriver driver;
        [Given(@"I open ""(.+)"" url")]
        public void GivenIOpenMainPage(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
