using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    public class StartPage
    {
        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
        private IWebElement signInButton;

        public const string BaseUrl = "http://www.github.com"; 

        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public SignInPage OpenSignInPage()
        {
            signInButton.Click();
            return new SignInPage(driver);
        }

    }
}
