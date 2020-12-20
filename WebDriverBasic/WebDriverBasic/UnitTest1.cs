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
            logPage = new LogPage(driver);
            mainPage.InputLogin("user", "user");
            Assert.AreNotEqual("Login",mainPage.SearchFormLogin());
        }       

        [Test] 
        public void Test2_Create_Product_Test()
        {
            allProductsPage = new AllProductsPage(driver);
            productPage = new ProductPage(driver);
            logPage.ClickOnAllProducts();
            allProductsPage.CreateNew();
            productPage.CreateProduct("Product_my", "Produce", "Mayumi's", "1000", "10", "500","4","1");
            Assert.AreNotEqual("Product editing", allProductsPage.FieldAllProductsText());

        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {
            productPage = new ProductPage(driver);
            allProductsPage.ClickOnProduct("Product_my");
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
            productPage.GoToProducts();
            allProductsPage.DeleteProduct();
            allProductsPage.ClickOnYes();
            Assert.Throws<OpenQA.Selenium.InvalidSelectorException>(() => driver.FindElement(By.XPath("=//td/a[text()=\"Product_my\"]")));
        }

        [Test]
        public void Test5_Logout_Test()
        {
            navigation.ClickOnLinkLogout();
            Assert.AreEqual("Login", logPage.LogPageText());
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}