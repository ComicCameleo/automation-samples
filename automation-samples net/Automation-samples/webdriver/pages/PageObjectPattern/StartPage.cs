using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    public class StartPage
    {
        private const string ButtonSignInXpathLocator = "//a[text()='Sign in']";
        public const string BaseUrl = "http://www.github.com"; 
        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SignInButton
        {
            get { return driver.FindElement(By.XPath(ButtonSignInXpathLocator)); }
        }


        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public SignInPage OpenSignInPage()
        {
            SignInButton.Click();
            return new SignInPage(driver);
        }

    }
}
