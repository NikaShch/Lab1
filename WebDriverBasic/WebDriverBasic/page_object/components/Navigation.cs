using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverFramework.page_object.components
{
    class Navigation
    {
        private IWebDriver driver;

        public Navigation(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement ProductLink => driver.FindElement(By.XPath("//li//a[text()=\"Products\"]"));
        IWebElement LogLink => driver.FindElement(By.LinkText("Logout"));

        public MainPage ClickOnLinkLogout()
        {
            new Actions(driver).Click(LogLink).Build().Perform();
            return new MainPage(driver);
        }

        public AllProductsPage ClickOnLinkProducts()
        {
            new Actions(driver).Click(ProductLink).Build().Perform();
            return new AllProductsPage(driver);
        }
    }
}
