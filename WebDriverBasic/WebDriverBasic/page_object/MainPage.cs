﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverAdvanced.page_object
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
        public void InputLogin(string name, string password)
        {
            new Actions(driver).SendKeys(FieldName, name).Build().Perform();
            new Actions(driver).SendKeys(FieldPassword, name).Build().Perform();
            new Actions(driver).MoveToElement(InputButton).Click(InputButton).Build().Perform();
        }

        public bool SearchFormLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("form[action='/Account/Login'")));
            return AccountLogin.Displayed;

        }
    }
}