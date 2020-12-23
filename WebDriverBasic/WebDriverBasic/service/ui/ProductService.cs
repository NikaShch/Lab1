using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
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
            int index = allProductsPage.GetCountProducts() + 1;
            ProductPage productPage = allProductsPage.GoToNewProduct();
            product.Index = index;
            productPage.InputProductName(product);
            productPage.InputCategoryName(product);
            productPage.InputSupplierName(product);
            productPage.InputUnitPrice(product);
            productPage.InputQuantityPerUnit(product);
            productPage.InputUnitsInStock(product);
            productPage.InputUnitsOnOrder(product);
            productPage.InputReorderLevel(product);
            return productPage.SendNewProduct();
        }
        //public static AllProductsPage NewProduct(Product product, IWebDriver driver)
        //{
        //    AllProductsPage allproductspage = new AllProductsPage(driver);
        //    ProductPage productpage = new ProductPage(driver);
        //    MainPage mainpage = new MainPage(driver);
        //    mainpage.GoToAllProducts();
        //    allproductspage.GoToNewProduct();
        //    productpage.CreateProduct(product);
        //    return productpage.SendNewProduct();
        //}
        public static ProductPage OpenProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            return allProductsPage.ClickOnProduct(product);
        }
        public static Product CreateProductFromFields(IWebDriver driver)
        {
            ProductPage productPage = new ProductPage(driver);
            string ProductName = productPage.GetProductName();
            string categoryId = productPage.GetCategoryName();
            string supplierId = productPage.GetSupplierName();
            int unitPrice = Convert.ToInt32(productPage.GetUnitPrice());
            string quantityPerUnit = productPage.GetQuantityPerUnit();
            int unitsInStock = Convert.ToInt32(productPage.GetUnitsInStock());
            int unitsOnOrder = Convert.ToInt32(productPage.GetUnitsOnOrder());
            int reorderLevel = Convert.ToInt32(productPage.GetReorderLevel());
            //bool discontinued = productPage.GetDiscontinued();
            Product product = new Product(ProductName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel);//, discontinued);
            return product;
        }
    }
}
