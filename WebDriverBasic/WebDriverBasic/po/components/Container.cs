using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebDriverAdvanced.po.components
{
    class Container
    {
        private IWebDriver driver;

        public Container(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement TitlePage => driver.FindElement(By.XPath("//h2"));

        public string GetTitlePage()
        {
            return TitlePage.Text;
        }
    }
}
