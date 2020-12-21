using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverAdvanced.page_object.components;

namespace WebDriverAdvanced.page_object
{
    class AllProductsPage
    {
        private IWebDriver driver;
        public Navigation navigation;


        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            navigation = new Navigation(driver);
        }

        private IWebElement FieldAllProducts => driver.FindElement(By.XPath("//h2"));
        private int CountProducts => driver.FindElements(By.XPath("//table//tr")).Count;
        private IWebElement CreateNewButton => driver.FindElement(By.LinkText("Create new"));
        private IWebElement Product_myDeleteButton => driver.FindElement(By.XPath("//*[a[text()=\"Product_my\"]]/following-sibling::*[10]/a[text()=\"Remove\"]"));
        public int GetCountProducts()
        {
            return CountProducts;
        }

        public void CreateNew()
        {
            new Actions(driver).Click(CreateNewButton).Build().Perform();
           
        }
        public bool ProductInTable(int index)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table//tr[" + index + "]")));
                return false;
            }
            catch (Exception) 
            { 
                return true; 
            }
        }
        public string FieldAllProductsText()
        {
            return FieldAllProducts.Text;
        }

        public ProductPage ClickOnProduct(int index)
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
