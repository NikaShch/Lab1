using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object.components;

namespace WebDriverFramework.page_object
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
        private IWebElement TableProduct => driver.FindElement(By.XPath("//table"));
        private IWebElement CreateNewButton => driver.FindElement(By.LinkText("Create new"));

        private int CountProducts => driver.FindElements(By.XPath("//table//tr")).Count;
        public By Create => By.CssSelector("form[action='/Product/Create']");
        public ProductPage CreateNew()
        {
            new Actions(driver).SendKeys(CreateNewButton, Keys.Enter).Build().Perform();
            return new ProductPage(driver);
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
        public int GetCount()
        {
            return CountProducts;
        }

        public ProductPage ClickOnProduct(Product product)
        {
            TableProduct.FindElement(By.XPath("//table//tr[" + product.Index + "]/td[2]/a")).Click();
            return new ProductPage(driver);
        }
        public By ProductInTable(Product product)
        {
            return By.XPath("//table//tr[" + product.Index + "]");
        }

        public void DeleteProduct(int index)
        {
            driver.FindElement(By.XPath("//table//tr[" + index + "]//a[text()=\"Remove\"]")).Click();
        }

        public bool ProductPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException) 
            {
                return false;
            }
        }
        public void ClickOnYes()
        {
            driver.SwitchTo().Alert().Accept();
        }
        public void GoToProduct(string product)
        {
            driver.FindElement(By.LinkText(product)).Click();
        }
        public ProductPage NewProduct()
        {
            new Actions(driver).SendKeys(CreateNewButton, Keys.Enter).Build().Perform();
            return new ProductPage(driver);
        }
        public By SearchByProductInTable(int index)
        {
            return By.XPath("//table//tr[" + index + "]");
        }
    }
}
