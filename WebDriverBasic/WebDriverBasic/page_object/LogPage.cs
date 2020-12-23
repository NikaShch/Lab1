using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverFramework.page_object
{
    class LogPage
    {
        private IWebDriver driver;

        public LogPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement FieldLoginPage => driver.FindElement(By.XPath("//h2"));
        IWebElement LinkAllProducts => driver.FindElement(By.XPath("//div/child::a[@href=\"/Product\"]"));

        public AllProductsPage ClickOnAllProducts()
        {
            new Actions(driver).SendKeys(LinkAllProducts, Keys.Enter).Build().Perform();
            return new AllProductsPage(driver);
        }
        public string LogPageText()
        {
            return FieldLoginPage.Text;
        }
    }
}
