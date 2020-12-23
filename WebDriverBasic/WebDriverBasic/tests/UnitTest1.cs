using NUnit.Framework;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object;
using WebDriverFramework.service.ui;
using WebDriverFramework.tests;

namespace WebDriverFramework
{
    public class Tests : BaseTest
    {
        
        private LogPage logPage;
        private AllProductsPage allProductsPage;
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