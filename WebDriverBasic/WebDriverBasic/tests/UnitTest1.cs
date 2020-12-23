using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object;
using WebDriverFramework.page_object.components;
using WebDriverFramework.service.ui;
using WebDriverFramework.tests;

namespace WebDriverFramework
{
    public class Tests : BaseTest
    {
        
        private LogPage logPage;
        private AllProductsPage allProductsPage;
       // private ProductPage productPage;
        public int index;
        private readonly Product my = new Product("My_product", "Produce", "Mayumi's", 1000, "10", 500, 4, 1);
        private readonly User myUser = new User("user", "user");

        [Test]
        public void Test1_Login_Test()
        {
            logPage = LoginService.UserLogin(myUser, driver);
            Assert.AreEqual(logPage.LogPageText(), "Home page");
        }       

        [Test] 
        public void Test2_Create_Product_Test()
        {
            allProductsPage = ProductService.CreateNewProduct(my, driver);
            Assert.IsFalse(allProductsPage.ProductPresent(allProductsPage.Create));
            Assert.IsTrue(allProductsPage.ProductPresent(allProductsPage.ProductInTable(my)));

            //productPage = new ProductPage(driver);
            //Assert.AreNotEqual(productPage.FieldAllProductsText(), ProductService.NewProduct(my, driver));
        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {
            ProductService.OpenProduct(my, driver);
            Product productMy = ProductService.CreateProductFromFields(driver);
            Assert.AreEqual(my, productMy);
        }
    }
}