using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverAdvanced.page_object;
using WebDriverAdvanced.page_object.components;

namespace WebDriverAdvanced
{
    public class Tests
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private LogPage logPage;
        private AllProductsPage allProductsPage;
        private ProductPage productPage;
        private Navigation navigation;
        public int index;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
           
        }

        [Test]
        public void Test1_Login_Test()
        {
            mainPage = new MainPage(driver);
            logPage = mainPage.InputLogin("user", "user");
            Assert.AreEqual(logPage.LogPageText(), "Home page");
        }       

        [Test] 
        public void Test2_Create_Product_Test()
        {
            allProductsPage = logPage.ClickOnAllProducts();
            int myindex = allProductsPage.GetCountProducts();
            productPage = allProductsPage.CreateNew();
            productPage.CreateProduct("Product_my", "Produce", "Mayumi's", "1000", "10", "500","4","1");
            allProductsPage = productPage.SendNewProduct();
            index = allProductsPage.GetCountProducts();
            Assert.AreEqual(myindex + 1, index);
            Assert.IsTrue(allProductsPage.ProductInTable(index));
        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {
            productPage = allProductsPage.ClickOnProduct(index);
            Assert.AreEqual("Product_my", productPage.GetProductName());
            Assert.AreEqual("Produce", productPage.GetCategoryName());
            Assert.AreEqual("Mayumi's", productPage.GetSupplierName());
            Assert.AreEqual("1000,0000", productPage.GetUnitPrice());
            Assert.AreEqual("10", productPage.GetQuantityPerUnit());
            Assert.AreEqual("500", productPage.GetUnitsInStock());
            Assert.AreEqual("4", productPage.GetUnitsOnOrder());
            Assert.AreEqual("1", productPage.GetReorderLevel());
            Assert.AreEqual("true", productPage.GetDiscontinued());
        }

        [Test]
        public void Test4_Delete_Product_Test()
        {
            allProductsPage = productPage.navigation.ClickOnLinkProducts();
            allProductsPage.DeleteProduct(index);
            allProductsPage.ClickOnYes();
            Assert.IsFalse(allProductsPage.ProductInTable(index));
        }

        [Test]
        public void Test5_Logout_Test()
        {
            mainPage = allProductsPage.navigation.ClickOnLinkLogout();
            Assert.AreEqual("Login", logPage.LogPageText());
            Assert.IsTrue(mainPage.SearchFormLogin());
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}