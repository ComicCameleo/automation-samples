using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using StartPage = Automation_samples.webdriver.pages.PageObjectPattern.StartPage;
using SignInPage = Automation_samples.webdriver.pages.PageObjectPattern.SignInPage;
using HomePage = Automation_samples.webdriver.pages.PageObjectPattern.HomePage;
using NewRepoPage = Automation_samples.webdriver.pages.PageObjectPattern.NewRepoPage;

namespace Automation_samples.webdriver.tests
{
    [TestClass]
    public class PageObjectTest
    {
        private const string USERNAME = "testautomationuser";
        private const string PASSWORD = "Time4Death!";
        IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            var ffBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            var firefoxProfile = new FirefoxProfile(@"C:\Users\Alesia_Karaliova\AppData\Roaming\Mozilla\Firefox\Profiles\f9zr5z1j.default");
            driver = new FirefoxDriver(ffBinary, firefoxProfile);
        }

        [TestMethod]
        public void TestOneCanLoginGithubPageObject()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            StartPage startPage = new StartPage(driver);
            startPage.OpenUrl();
            SignInPage signInPage = startPage.OpenSignInPage();
            HomePage homePage = signInPage.SignIn(USERNAME, PASSWORD);
            string loggedInUserName = homePage.GetLoggedInUserName();

            Assert.AreEqual(USERNAME, loggedInUserName);
            driver.Quit();
        }

        [TestMethod]
        public void CreateRepo()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            StartPage startPage = new StartPage(driver);
            startPage.OpenUrl();
            SignInPage signInPage = startPage.OpenSignInPage();
            HomePage homePage = signInPage.SignIn(USERNAME, PASSWORD);
            NewRepoPage repoPage= homePage.OpenRepoPage();
            Assert.IsTrue(repoPage.CheckRepoPageLabelEnabled());
            driver.Quit();
        }


    }
}
