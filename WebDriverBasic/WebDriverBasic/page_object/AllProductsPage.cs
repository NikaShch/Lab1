using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
namespace WebDriverAdvanced.page_object
{
    class AllProductsPage
    {
        private IWebDriver driver;

        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private int CountProducts => driver.FindElement(By.XPath("//table/tr")).Count;
        private IWebDriver CreateNewButton => (IWebDriver)driver.FindElement(By.LinkText("Create new"));

        public int GetCountProducts()
        {
            return CountProducts;
        }

        public ProductPage CreateNew()
        {
            new Actions(driver).SendKeys((IWebElement)CreateNewButton, Keys.Enter).Build().Perform();
            return new ProductPage(driver);
        }

        public IWebElement ProductOnTable(int index)
        {
            return driver.FindElement(By.XPath("//table//tr[" + index + "]"));
        }

        public ProductPage ClickOnLinkProduct(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + index + "]/td[2]/a")).Click();
            return new ProductPage(driver);
        }

        public void DeleteProduct(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + index + "]//a[text()=\"Remove\"]")).Click();
        }

        public void ClickOnYes()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
