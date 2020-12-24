using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using WebDriverFramework.page_object;

namespace WebDriverFramework.step_definitions
{
    [Binding]
    class ProductSteps
    {
        public int index;
        private IWebDriver driver;
        [Given(@"I open ""(.+)"" url")]
        public void GivenIOpenMainPage(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }
        [When(@"I log into with username ""(.+)"" and password ""(.+)""")]
        public void WhenILogIntoWithUsernameAndPassword(string name, string password)
        {
            new MainPage(driver).InputLogin(name, password);
        }

        [When(@"I click on send button")]
        public void WhenIClickOnSendButton()
        {
            new MainPage(driver).ClickOnSendButton();
        }

        [Then(@"I go to the home page")]
        public void ThenIGoToTheHomePage()
        {
            Assert.AreEqual(new LogPage(driver).LogPageText(), "Home page");
        }

        [When(@"I click on the all products")]
        public void ThenIClickOnTheAllProducts()
        {
            new LogPage(driver).ClickOnAllProducts();
        }

        [When(@"I click on create new product")]
        public void ThenIClickOnCreateNewProduct()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            index = allProductsPage.GetCount() + 1;
            allProductsPage.NewProduct();

        }

        [When(@"I create a product with fields ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", (.*), (.*), (.*), (.*)")]
        public void WhenICreateAProductWithFields(string name, string category, string supplier, string quantity, int price, int stock, int order, int level)
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.InputProductName(name);
            productPage.InputCategoryId(category);
            productPage.InputSupplierId(supplier);
            productPage.InputUnitPrice(price);
            productPage.InputQuantityPerUnit(quantity);
            productPage.InputUnitsInStock(stock);
            productPage.InputUnitsOnOrder(order);
            productPage.InputReorderLevel(level);
        }

        [When(@"I click on send button product")]
        public void WhenIClickOnSendButtonProduct()
        {
            new ProductPage(driver).GetNewProduct();
        }

        [Then(@"The form of creation disappeared")]
        public void ThenTheFormOfCreationDisappeared()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            Assert.IsFalse(allProductsPage.ProductPresent(allProductsPage.Create));
        }

        [Then(@"The product should be on all products page")]
        public void ThenTheProductShouldBeOnAllProductsPage()
        {
            AllProductsPage allProductsPage = new AllProductsPage(driver);
            Assert.IsTrue(allProductsPage.ProductPresent(allProductsPage.SearchByProductInTable(index)));
        }
        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
