using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebDriverAdvanced.po
{
    class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
