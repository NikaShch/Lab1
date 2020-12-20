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

        private IWebElement FieldAllProducts => driver.FindElement(By.XPath("//h2"));
        
        private IWebElement CreateNewButton => driver.FindElement(By.LinkText("Create new"));
        private IWebElement Product_myDeleteButton => driver.FindElement(By.XPath("//*[a[text()=\"Product_my\"]]/following-sibling::*[10]/a[text()=\"Remove\"]"));

        public void CreateNew()
        {
            new Actions(driver).Click(CreateNewButton).Build().Perform();
           
        }
        public string FieldAllProductsText()
        {
            return FieldAllProducts.Text;
        }

        public void ClickOnProduct(string product)
        {
            driver.FindElement(By.LinkText(product)).Click();
        }

        public void DeleteProduct()
        {
            new Actions(driver).Click(Product_myDeleteButton).Build().Perform();
        }

        public void ClickOnYes()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
