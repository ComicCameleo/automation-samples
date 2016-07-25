using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    public class SignInPage
    {
        [FindsBy(How = How.Id, Using = "login_field")]
        private IWebElement loginInput;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//input[@value='Sign in']")]
        private IWebElement submitButton;

        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public HomePage SignIn(string username, string password)
        {
            loginInput.SendKeys(username);
            passwordInput.SendKeys(password);
            submitButton.Click();
            return new HomePage(driver);
        }
    }

}
