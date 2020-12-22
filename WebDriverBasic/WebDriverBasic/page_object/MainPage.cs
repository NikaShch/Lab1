using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverFramework.business_objects;

namespace WebDriverFramework.page_object
{
    class MainPage
    {
        private IWebDriver driver;

        public  MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FieldName => driver.FindElement(By.Id("Name"));
        private IWebElement FieldPassword => driver.FindElement(By.Id("Password"));
        private IWebElement InputButton => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement FieldLoginPage => driver.FindElement(By.XPath("//h2"));
        private IWebElement AccountLogin => driver.FindElement(By.CssSelector("form[action='/Account/Login']"));
        private IWebElement AllProductsButton => driver.FindElement(By.LinkText("All Products"));

        public LogPage InputLogin(User user)
        {
            new Actions(driver).SendKeys(FieldName, user.Name).SendKeys(FieldPassword, user.Password).Build().Perform();
            new Actions(driver).SendKeys(InputButton, Keys.Enter).Build().Perform();
            return new LogPage(driver);
        }

        public bool SearchFormLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("form[action='/Account/Login'")));
            return AccountLogin.Displayed;

        }
        public string HomePage()
        {
            return FieldLoginPage.Text;
        }
        public void GoToAllProducts()
        {
            new Actions(driver).MoveToElement(AllProductsButton).Click(AllProductsButton).Build().Perform();
        }
    }
}
