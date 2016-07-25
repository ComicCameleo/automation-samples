using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    public class SignInPage
    {
        private const string LoginInputIdLocator = "login_field";
        private const string PasswordInputId = "password";
        private const string SubmitButtonXpath = "//input[@value='Sign in']";

        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LoginInput
        {
            get { return driver.FindElement(By.Id(LoginInputIdLocator)); }
        }

        public IWebElement PasswordInput
        {
            get { return driver.FindElement(By.Id(PasswordInputId)); }
        }

        public IWebElement SubmitButton
        {
            get { return driver.FindElement(By.XPath(SubmitButtonXpath)); }
        }

        public HomePage SignIn(string username, string password)
        {
            LoginInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
            return new HomePage(driver);
        }

    }

}
