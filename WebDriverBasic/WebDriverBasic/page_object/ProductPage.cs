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


        private IWebElement Button => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement FieldAllProducts => driver.FindElement(By.XPath("//h2"));     
        
        public void InputProductName(Product product)
        {
            new Actions(driver).SendKeys(ProductNameField, product.ProductName).Build().Perform();
        }
        public void InputCategoryId(Product product)
        {
            new Actions(driver).Click(CategoryIdField).SendKeys(product.CategoryId).Build().Perform();
        }
        public void InputSupplierId(Product product)
        {
            new Actions(driver).Click(SupplierIdField).SendKeys(product.SupplierId).Build().Perform();
        }
        public void InputUnitPrice(Product product)
        {
            new Actions(driver).SendKeys(UnitPriceField, product.UnitPrice).Build().Perform();
        }
        public void InputQuantityPerUnit(Product product)
        {
            new Actions(driver).SendKeys(QuantityPerUnitField, product.QuantityPerUnit).Build().Perform();
        }
        public void InputUnitsInStock(Product product)
        {
            new Actions(driver).SendKeys(UnitsInStockField, product.UnitsInStock.ToString()).Build().Perform();
        }

        public void InputUnitsOnOrder(Product product)
        {
            new Actions(driver).SendKeys(UnitsOnOrderField, product.UnitsOnOrder).Build().Perform();
        }

        public void InputReorderLevel(Product product)
        {
            new Actions(driver).SendKeys(ReorderLevelField, product.ReorderLevel).Build().Perform();
        }
        

        public string FieldAllProductsText()
        {
            return FieldAllProducts.Text;
        }

        public string GetProductName()
        {
            return ProductNameField.GetAttribute("value");
        }

        public string GetCategoryId()
        {
            return CategoryIdField.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
        }

        public string GetSupplierId()
        {
            return SupplierIdField.FindElement(By.XPath("./option[@selected=\"selected\"]")).Text;
        }

        public string GetUnitPrice()
        {
            string unitPrice = UnitPriceField.GetAttribute("value");
            return unitPrice.Substring(0, unitPrice.Length - 5);
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

        public AllProductsPage GetNewProduct()
        {
            new Actions(driver).Click(Button).Build().Perform();
            return new AllProductsPage(driver);
        }
        public void InputProductName(string name)
        {
            ProductNameField.SendKeys(name);
        }
        public void InputCategoryId(string category)
        {
            CategoryIdField.SendKeys(category);
        }
        public void InputSupplierId(string supplier)
        {
            SupplierIdField.SendKeys(supplier);
        }
        public void InputUnitPrice(int price)
        {
            UnitPriceField.SendKeys(price.ToString());
        }
        public void InputQuantityPerUnit(string quantity)
        {
            QuantityPerUnitField.SendKeys(quantity);
        }
        public void InputUnitsInStock(int stock)
        {
            UnitsInStockField.SendKeys(stock.ToString());
        }
        public void InputUnitsOnOrder(int order)
        {
            UnitsOnOrderField.SendKeys(order.ToString());
        }
        public void InputReorderLevel(int level)
        {
            ReorderLevelField.SendKeys(level.ToString());
        }
    }
}
