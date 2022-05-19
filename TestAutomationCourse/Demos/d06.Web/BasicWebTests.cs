using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationCourse.Demos.d06.Web.d1.Basic
{
    internal class BasicWebTests
    {
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void navigate_and_check_title()
        {
            driver.Url = "http://www.google.com";
            Assert.That(driver.Title, Is.EqualTo("Google"));
        }

        [Test]
        public void navigate_back_and_forward()
        {
            driver.Url = "http://www.google.com";
            driver.Url = "http://www.amazon.com";
            driver.Navigate().Back();
            Assert.That(driver.Title, Is.EqualTo("Google"));
            driver.Navigate().Forward();
            Assert.That(driver.Title, Does.Contain("Amazon"));
        }

        [Test]
        public void click_a_link()
        {
            driver.Url = "http://www.google.com";
            IWebElement gmail_link = driver.FindElement(By.LinkText("Gmail"));
            gmail_link.Click();
            Assert.That(driver.Title, Does.Contain("Gmail"));
        }


        [Test]
        public void enter_text_submit()
        {
            driver.Url = "http://www.duckduckgo.com";
            IWebElement search_input = driver.FindElement(By.Name("q"));
            search_input.SendKeys("automation");
            search_input.Submit();
            Assert.That(driver.Title, Does.Contain("automation"));
        }

        [Test]
        public void find_active_element()
        {
            driver.Url = "http://www.duckduckgo.com";
            IWebElement search_input = driver.FindElement(By.CssSelector(
                "[name='q']"));
            search_input.SendKeys("automation");
            IWebElement search_input2 = driver.SwitchTo().ActiveElement();
            Assert.That(search_input2, Is.EqualTo(search_input));
        }

        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }

    }
}
