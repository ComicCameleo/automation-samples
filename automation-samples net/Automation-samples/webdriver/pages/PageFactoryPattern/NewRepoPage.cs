using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    public class NewRepoPage
    {
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Create a new repository')]")]
        private IWebElement repoPageLabel;

        IWebDriver driver;

        public NewRepoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool CheckRepoPageLabelEnabled()
        {
            return repoPageLabel.Enabled;

        }

    }
}
