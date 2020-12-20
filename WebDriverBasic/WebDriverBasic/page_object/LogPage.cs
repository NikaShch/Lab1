using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverAdvanced.page_object
{
    class LogPage
    {
        private IWebDriver driver;

        public LogPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement FieldLoginPage => driver.FindElement(By.XPath("//h2"));
        private IWebElement LinkAllProducts => driver.FindElement(By.LinkText("All Products"));

        public void ClickOnAllProducts()
        {
            new Actions(driver).MoveToElement(LinkAllProducts).Click(LinkAllProducts).Build().Perform();
            
        }
        public string LogPageText()
        {
            return FieldLoginPage.Text;
        }
    }
}
