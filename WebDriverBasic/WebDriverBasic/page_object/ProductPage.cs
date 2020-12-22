using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object.components;

namespace WebDriverFramework.page_object
{
    class ProductPage
    {
        private IWebDriver driver;
        public Navigation navigation;


        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            navigation = new Navigation(driver);
        }

        private IWebElement ProductNameField => driver.FindElement(By.Id("ProductName"));
        private IWebElement CategoryIdField => driver.FindElement(By.Id("CategoryId"));
        private IWebElement SupplierIdField => driver.FindElement(By.Id("SupplierId"));

        private IWebElement UnitPriceField => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement QuantityPerUnitField => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement UnitsInStockField => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement UnitsOnOrderField => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement ReorderLevelField => driver.FindElement(By.Id("ReorderLevel"));

        private IWebElement DiscontinuedField => driver.FindElement(By.Id("Discontinued"));

        private IWebElement SendButton => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement FieldAllProducts => driver.FindElement(By.XPath("//h2"));

        
        public void CreateProduct(Product product)
        {
            new Actions(driver).SendKeys(ProductNameField, product.ProductName).Build().Perform();
            new Actions(driver).SendKeys(CategoryIdField, product.CategoryId).Build().Perform();
            new Actions(driver).SendKeys(SupplierIdField, product.SupplierId).Build().Perform();
            new Actions(driver).SendKeys(UnitPriceField, product.UnitPrice).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnitField, product.QuantityPerUnit).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStockField, product.UnitsInStock).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrderField, product.UnitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevelField, product.ReorderLevel).Build().Perform();
            new Actions(driver).Click(DiscontinuedField).Build().Perform();
            new Actions(driver).Click(SendButton).Build().Perform();
        }
        public string FieldAllProductsText()
        {
            return FieldAllProducts.Text;
        }

        public string GetProductName()
        {
            return ProductNameField.GetAttribute("value");
        }

        public string GetCategoryName()
        {
            return CategoryIdField.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
        }

        public string GetSupplierName()
        {
            return SupplierIdField.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
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
        
        public AllProductsPage SendNewProduct()
        {
            new Actions(driver).Click(SendButton).Build().Perform();
            return new AllProductsPage(driver);
        }

    }
}
