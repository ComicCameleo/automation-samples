using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using StartPage = Automation_samples.webdriver.pages.PageFactoryPattern.StartPage;
using SignInPage = Automation_samples.webdriver.pages.PageFactoryPattern.SignInPage;
using HomePage = Automation_samples.webdriver.pages.PageFactoryPattern.HomePage;
using NewRepoPage = Automation_samples.webdriver.pages.PageFactoryPattern.NewRepoPage;


namespace Automation_samples.webdriver.tests
{
    [TestClass]
    public class PageFactoryTest
    {
        private const string userName = "testautomationuser";
        private const string password = "Time4Death!";
        IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            var ffBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            var firefoxProfile = new FirefoxProfile(@"C:\Users\Alesia_Karaliova\AppData\Roaming\Mozilla\Firefox\Profiles\f9zr5z1j.default");
            driver = new FirefoxDriver(ffBinary, firefoxProfile);
        }

        [TestMethod]
        public void TestOneCanLoginGithubPageFactory()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            StartPage startPage = new StartPage(driver);
            startPage.OpenUrl();
            SignInPage signInPage = startPage.OpenSignInPage();
            HomePage homePage = signInPage.SignIn(userName, password);
            string loggedInUserName = homePage.GetLoggedInUserName();

            Assert.AreEqual(userName, loggedInUserName);
            driver.Quit();
        }

        [TestMethod]
        public void CreateRepoFactory()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            StartPage startPage = new StartPage(driver);
            startPage.OpenUrl();
            SignInPage signInPage = startPage.OpenSignInPage();
            HomePage homePage = signInPage.SignIn(userName, password);
            NewRepoPage repoPage = homePage.OpenRepoPage();
            Assert.IsTrue(repoPage.CheckRepoPageLabelEnabled());
            driver.Quit();
        }

    }
}
