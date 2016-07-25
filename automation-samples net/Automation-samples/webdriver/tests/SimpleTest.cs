using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace Automation_samples.webdriver.tests
{
    [TestClass]
    public class SimpleTest
    {
        private const String USERNAME = "testautomationuser";
        IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            var ffBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            var firefoxProfile = new FirefoxProfile(@"C:\Users\Alesia_Karaliova\AppData\Roaming\Mozilla\Firefox\Profiles\f9zr5z1j.default");
            firefoxProfile.EnableNativeEvents=true;
            driver = new FirefoxDriver(ffBinary, firefoxProfile);
        }

        [TestMethod]
        public void TestOneCanLoginGithub()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://www.github.com/");
            driver.FindElement(By.XPath("//a[text()='Sign in']")).Click();
            driver.FindElement(By.XPath("//input[@id='login_field']")).SendKeys(USERNAME);
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Time4Death!");
            driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            string loggedInUserName = driver.FindElement(By.XPath("//button[@aria-label='Switch account context']/span")).Text;
            Console.WriteLine(loggedInUserName);
            Assert.AreEqual(USERNAME, loggedInUserName);
            driver.Quit();
        }


    }
}
