using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebDriverAdvanced.page_object
{
    class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductNameField => driver.FindElement(By.XPath("//*[@id=\"ProductId\"]"));
        private IWebElement CategoryIdField => driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]"));

        private IWebElement SupplierIdField => driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]"));

        private IWebElement UnitPriceField => driver.FindElement(By.XPath("//*[@id=\"UnitPriceId\"]"));
        private IWebElement QuantityPerUnitField => driver.FindElement(By.XPath("//*[@id=\"QuantityPerUnitId\"]"));
        private IWebElement UnitsInStockField => driver.FindElement(By.XPath("//*[@id=\"UnitsInStockId\"]"));
        private IWebElement UnitsOnOrderField => driver.FindElement(By.XPath("//*[@id=\"UnitsOnOrderId\"]"));
        private IWebElement ReorderLevelField => driver.FindElement(By.XPath("//*[@id=\"ReorderLevelId\"]"));

        private IWebElement DiscontinuedField => driver.FindElement(By.XPath("//*[@id=\"DiscontinuedId\"]"));

        private IWebElement SendButton => driver.FindElement(By.CssSelector(".btn"));

        public void CreateProduct(string product_name, string categoryid, string supplierid, string unitprice, string quantityperunit, string unitsinstock, string unitsonoder, string reorderlevel)
        {
            new Actions(driver).SendKeys(ProductNameField, product_name).Build().Perform();
            new Actions(driver).SendKeys(CategoryIdField, categoryid).Build().Perform();
            new Actions(driver).SendKeys(SupplierIdField, supplierid).Build().Perform();
            new Actions(driver).SendKeys(UnitPriceField, unitprice).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnitField, quantityperunit).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStockField, unitsinstock).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrderField, unitsonoder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevelField, reorderlevel).Build().Perform();
            new Actions(driver).Click(DiscontinuedField).Build().Perform();
            new Actions(driver).Click(SendButton).Build().Perform();
        }

      public string GetProductName()
        {
            return ProductNameField.GetAttribute("value");
        }

        public string GetCategoryName()
        {
            return CategoryIdField.Text;
        }

        public string GetSupplierName()
        {
            return SupplierIdField.Text;
        }

        public string GetUnitPrice()
        {
            return UnitPriceField.GetAttribute("value");
        }

        public string GetQuantityPerUnit()
        {
            return QuantityPerUnitField.GetAttribute("value");
        }

        public string GetUnitsInStock()
        {
            return UnitsInStockField.GetAttribute("value");
        }

        public string GetUnitsOnOrder()
        {
            return UnitsOnOrderField.GetAttribute("value");
        }

        public string GetReorderLevel()
        {
            return ReorderLevelField.GetAttribute("value");
        }

        public string GetDiscontinued()
        {
            return DiscontinuedField.GetAttribute("checked");
        }



    }
}
