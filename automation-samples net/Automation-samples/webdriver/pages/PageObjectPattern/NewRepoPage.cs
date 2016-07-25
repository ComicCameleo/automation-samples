using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    public class NewRepoPage
    {
        private const string RepoPageLabelXpath = "//h2[contains(text(),'Create a new repository')]";
        private IWebDriver driver;

       public NewRepoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement RepoPageLabel
        {
            get { return driver.FindElement(By.XPath(RepoPageLabelXpath)); }
        }

        public bool CheckRepoPageLabelEnabled()
        {
            return RepoPageLabel.Enabled;

        }
    }
}
