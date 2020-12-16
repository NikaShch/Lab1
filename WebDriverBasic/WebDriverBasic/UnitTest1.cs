using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using WebDriverAdvanced.po;
using WebDriverAdvanced.po.components;

namespace WebDriverAdvanced
{
    public class Tests
    {
        private IWebDriver driver;
        public static int count;
        private MainPage mainPage;
        private LogPage logPage;
        private AllProductsPage allProductsPage;
        private ProductPage productPage;
        private Navigation navigation;
        private Container container;
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
            logPage = mainPage.ClickOnInputLogin("user", "user");
            container = new Container(driver);
            Assert.AreEqual(container.GetTitlePage(), "Home page");
        }

        [Test] 
        public void Test2_Create_Product_Test()
        {
            allProductsPage = logPage.ClickOnAllProducts();
            int myindex = allProductsPage.GetCountProducts();
            productPage = allProductsPage.ClickOnCreateNew();

            productPage.InputProductName("Product_my");
            productPage.InputCategoryName("Produce");
            productPage.InputSupplierName("Mayumi's");
            productPage.InputUnitPrice("1000");
            productPage.InputQuantityPerUnit("10");
            productPage.InputUnitsInStock("500");
            productPage.InputUnitsOnOrder("4");
            productPage.InputReorderLevel("1");
            productPage.ClickOnDiscontinued();

            allProductsPage = productPage.ClickOnSendNewProduct();
            index = allProductsPage.GetCountProducts();

            Assert.IsEmpty(productPage.SearchFormCreate());
            Assert.AreEqual(myindex + 1, index);
            Assert.IsTrue(allProductsPage.ProductOnTable(index).Displayed);

        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {
            productPage = allProductsPage.ClickOnLinkProduct(index);
            Assert.AreEqual("Product_my", productPage.GetProductNameValue());
            Assert.AreEqual("Produce", productPage.GetCategoryNameText());
            Assert.AreEqual("Mayumi's", productPage.GetSupplierNameText());
            Assert.AreEqual("1000,0000", productPage.GetUnitPriceValue());
            Assert.AreEqual("10", productPage.GetQuantityPerUnitValue());
            Assert.AreEqual("500", productPage.GetUnitsInStockValue());
            Assert.AreEqual("4", productPage.GetUnitsOnOrderValue());
            Assert.AreEqual("1", productPage.GetReorderLevelValue());
            Assert.AreEqual("true", productPage.GetDiscontinuedValue());
        }

        [Test]
        public void Test4_Delete_Product_Test()
        {
            navigation = new Navigation(driver);
            allProductsPage = navigation.ClickOnLinkProducts();
            allProductsPage.ClickOnDeleteProduct(index);
            allProductsPage.ClickOnYes();
            Assert.IsFalse(allProductsPage.ProductOnTable(index).Selected);
        }

        [Test]
        public void Test5_Logout_Test()
        {
            mainPage = navigation.ClickOnLinkLogout();
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