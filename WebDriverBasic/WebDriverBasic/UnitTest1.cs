using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverBasic
{
    public class Tests
    {
        private IWebDriver driver;
        //private WebDriverWait wait;

        [SetUp]
        public void TestFixtureSetUp()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Test]
        public void Test1_Login_Test()
        {
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            var hp = driver.FindElement(By.XPath("//h2[contains(.,'Home page')]")).Text;
            Assert.AreEqual("Home page", hp);
        }

        [Test] 
        public void Test2_Create_Product_Test()
        {
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            driver.FindElement(By.LinkText("Create new")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("Product_my");
            driver.FindElement(By.Id("CategoryId")).SendKeys("Produce");
            driver.FindElement(By.Id("SupplierId")).SendKeys("Mayumi's");
            driver.FindElement(By.Id("UnitPrice")).SendKeys("1000");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("10");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("500");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("4");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("1");
            driver.FindElement(By.Id("Discontinued")).Click(); 
            driver.FindElement(By.CssSelector(".btn")).Click();
            var ap = driver.FindElement(By.XPath("//div/h2")).Text;
            Assert.AreEqual("All Products", ap);
            
        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {   
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            driver.FindElement(By.XPath("//tr[79]")).Click();
            var td2 = driver.FindElement(By.XPath("//tr[79]/td[2]")).Text;
            var td3 = driver.FindElement(By.XPath("//tr[79]/td[3]")).Text;
            var td4 = driver.FindElement(By.XPath("//tr[79]/td[4]")).Text;
            var td5 = driver.FindElement(By.XPath("//tr[79]/td[5]")).Text;
            var td6 = driver.FindElement(By.XPath("//tr[79]/td[6]")).Text;
            var td7 = driver.FindElement(By.XPath("//tr[79]/td[7]")).Text;
            var td8 = driver.FindElement(By.XPath("//tr[79]/td[8]")).Text;
            var td9 = driver.FindElement(By.XPath("//tr[79]/td[9]")).Text;
            var td10 = driver.FindElement(By.XPath("//tr[79]/td[10]")).Text;
            Assert.AreEqual("Product_my", td2);
            Assert.AreEqual("Produce", td3);
            Assert.AreEqual("Mayumi's", td4);
            Assert.AreEqual("10", td5);
            Assert.AreEqual("1000,0000", td6);
            Assert.AreEqual("500", td7);
            Assert.AreEqual("4", td8);
            Assert.AreEqual("1", td9);
            Assert.AreEqual("True", td10);
        }

        [Test]
        public void Test4_Delete_Product_Test()
        {
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            driver.FindElement(By.XPath("//tr[79]/td[12]/a")).Click();
            driver.FindElement(By.XPath("Are you sure?")).SendKeys(Keys.Enter);
            //Actions builder = new Actions(driver);
            //builder.SendKeys(Keys.Enter);
            //как посмотреть код всплывающего окна, пока не получилось

        }

        [Test]
        public void Test5_Logout_Test()
        {
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),\"L\")]")).Click();
            driver.FindElement(By.CssSelector("footer")).Click();
            var al = new driver.FindElement(By.XPath("//form[@action=\"/Account/Login\"]")).Click();
            Assert.AreEqual("/Account/Login", al);

        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}