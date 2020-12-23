using OpenQA.Selenium;
using WebDriverFramework.business_objects;
using WebDriverFramework.page_object;

namespace WebDriverFramework.service.ui
{
    class LoginService
    {
        public static LogPage UserLogin(User user, IWebDriver driver)
        {
            MainPage mainpage = new MainPage(driver);
            return mainpage.InputLogin(user);
        }
        public static string SingOut(IWebDriver driver)
        {
            MainPage mainpage = new MainPage(driver);
            return mainpage.HomePage();
        }
    }
}
