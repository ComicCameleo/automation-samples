using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Switch account context']/span")]
        private IWebElement loggedInUserlink;

        [FindsBy(How = How.XPath, Using = "//div/a[contains(text(), 'New repository')]")]
        private IWebElement repoPageButton; 

        [FindsByAll]

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetLoggedInUserName()
        {
            return loggedInUserlink.Text;
        }

        public NewRepoPage OpenRepoPage()
        {
            repoPageButton.Click();
            return new NewRepoPage(driver);
        }
    }

}
