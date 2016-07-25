using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    public class HomePage
    {
        private const string LoggedInUserLinkXpath = "//button[@aria-label='Switch account context']/span";
        private const string NewRepoButtonXpath = "//div/a[contains(text(), 'New repository')]";

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLoggedInUserName()
        {
            return LoggedInUserLink.Text;
        }

        public IWebElement LoggedInUserLink
        {
            get { return driver.FindElement(By.XPath(LoggedInUserLinkXpath)); }
        }

        public IWebElement NewRepository
        {
            get { return driver.FindElement(By.XPath(NewRepoButtonXpath)); }
        }

        public NewRepoPage OpenRepoPage()
        {
            NewRepository.Click();
            return new NewRepoPage(driver);
        }
    }

}
