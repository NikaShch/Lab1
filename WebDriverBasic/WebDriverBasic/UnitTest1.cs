using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverBasic
{
    public class Tests
    {
        private IWebDriver driver;
        public static int count;
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//input[@id='Name']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        [Test]
        public void Test1_Login_Test()
        {
        
            var home = driver.FindElement(By.XPath("//h2[contains(.,'Home page')]")).Text;
            Assert.AreEqual("Home page", home);
        }

        [Test] 
        public void Test2_Create_Product_Test()
        {
            driver.FindElement(By.XPath("//div/child::a[@href=\"/Product\"]")).Click();
            count = driver.FindElements(By.XPath("//table//tr")).Count;
            driver.FindElement(By.LinkText("Create new")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("Product_my");
            driver.FindElement(By.XPath("//select[@name=\"CategoryId\"]/option[@value=7]")).Click();
            driver.FindElement(By.XPath("//select[@name=\"SupplierId\"]/option[@value=6]")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("1000");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("10");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("500");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("4");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("1");
            driver.FindElement(By.Id("Discontinued")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            var all_products = driver.FindElement(By.XPath("//div/h2")).Text;
            Assert.AreEqual("All Products", all_products);
            Assert.IsEmpty(driver.FindElements(By.XPath("//form[@action=\"/Product/Create\"]")));
            count++;
            Assert.IsTrue(driver.FindElement(By.XPath("//table//tr[" + count + "]")).Displayed);

        }

        [Test]
        public void Test3_Open_Created_Product_Test()
        {
            driver.FindElement(By.XPath("//table//tr[" + count + "]/td[2]/a")).Click();
            Assert.AreEqual("Product_my", driver.FindElement(By.XPath("//input[@id=\"ProductName\"]")).GetAttribute("value"));
            Assert.AreEqual("7", driver.FindElement(By.Id("CategoryId")).GetAttribute("value"));
            Assert.AreEqual("6", driver.FindElement(By.Id("SupplierId")).GetAttribute("value"));
            Assert.AreEqual("1000,0000", driver.FindElement(By.Id("UnitPrice")).GetAttribute("value"));
            Assert.AreEqual("10", driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value"));
            Assert.AreEqual("500", driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value"));
            Assert.AreEqual("4", driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value"));
            Assert.AreEqual("1", driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value"));
            Assert.AreEqual("true", driver.FindElement(By.Id("Discontinued")).GetAttribute("value"));
        }

        [Test]
        public void Test4_Delete_Product_Test()
        {
            driver.FindElement(By.XPath("//li//a[text()=\"Products\"]")).Click();
            driver.FindElement(By.XPath("//table//tr[" + count + "]//a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            Assert.IsFalse(driver.FindElement(By.XPath("//table//tr[" + count + "]")).Selected);
        }

        [Test]
        public void Test5_Logout_Test()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            IWebElement element = driver.FindElement(By.XPath("//form[@action=\"/Account/Login\"]"));
            Assert.IsTrue(element.Displayed);
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}