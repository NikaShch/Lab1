using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object;

namespace WebDriverFramework.service.ui
{
    class ProductService
    {
        public static AllProductsPage NewProduct(Product product, IWebDriver driver)
        {
            AllProductsPage allproductspage = new AllProductsPage(driver);
            ProductPage productpage = new ProductPage(driver);
            MainPage mainpage = new MainPage(driver);
            mainpage.GoToAllProducts();
            allproductspage.GoToNewProduct();
            productpage.CreateProduct(product);
            return productpage.SendNewProduct();
        }

    }
}
