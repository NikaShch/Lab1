using OpenQA.Selenium;
using System;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object;

namespace WebDriverFramework.service.ui
{
    class ProductService
    {
        public static AllProductsPage CreateNewProduct(Product product, IWebDriver driver)
        {
            LogPage logPage = new LogPage(driver);
            AllProductsPage allProductsPage = logPage.ClickOnAllProducts();
            int index = allProductsPage.GetCount() + 1;
            ProductPage productPage = allProductsPage.NewProduct();
            product.Index = index;
            productPage.InputProductName(product);
            productPage.InputCategoryId(product);
            productPage.InputSupplierId(product);
            productPage.InputUnitPrice(product);
            productPage.InputQuantityPerUnit(product);
            productPage.InputUnitsInStock(product);
            productPage.InputUnitsOnOrder(product);
            productPage.InputReorderLevel(product);
            return productPage.GetNewProduct();
        }
        public static ProductPage OpenProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            return allProductsPage.ClickOnProduct(product);
        }
        public static Product FormProduct(IWebDriver driver)
        {
            ProductPage productPage = new ProductPage(driver);
            string ProductName = productPage.GetProductName();
            string categoryId = productPage.GetCategoryId();
            string supplierId = productPage.GetSupplierId();
            int unitPrice = Convert.ToInt32(productPage.GetUnitPrice());
            string quantityPerUnit = productPage.GetQuantityPerUnit();
            int unitsInStock = Convert.ToInt32(productPage.GetUnitsInStock());
            int unitsOnOrder = Convert.ToInt32(productPage.GetUnitsOnOrder());
            int reorderLevel = Convert.ToInt32(productPage.GetReorderLevel());
            Product product = new Product(ProductName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel);//, discontinued);
            return product;
        }
    }
}
