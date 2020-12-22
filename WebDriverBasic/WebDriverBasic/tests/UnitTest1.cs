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
        
        private MainPage mainPage;
        private LogPage logPage;
        private AllProductsPage allProductsPage;
        private ProductPage productPage;
        private Navigation navigation;
        public int index;
        private readonly Product my = new Product("Product_my", "Produce", "Mayumi's", 1000, "10", 500, 4, 1, true);
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
            productPage = new ProductPage(driver);
            Assert.AreNotEqual(productPage.FieldAllProductsText(), ProductService.NewProduct(my, driver));
        }

    }
}