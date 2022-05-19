using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace TestAutomationCourse.Exercises.e09.Web
{
    [TestFixture]
    internal class BasicTests
    {
        // click the "about" link, which is not a link, on the google page

        // find the name of the google image
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void submitting_data_and_verifying()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement name_text = driver.FindElement(By.Name("firstName"));
            name_text.SendKeys("Gil");
            IWebElement submit_button = driver.FindElement(By.Name("submit"));
            submit_button.Click();
            var paragraphs = driver.FindElements(By.TagName("p"));
            var p_containing_dear_gil = paragraphs.FirstOrDefault(p => p.Text.Contains("Dear Gil"));
            Assert.That(p_containing_dear_gil, Is.Not.Null);
            var p_containing_note = paragraphs.FirstOrDefault(p => p.Text.Contains("Note"));
            Assert.That(p_containing_note.Text, Does.Not.Contain("Gil"));
        }

        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }


    }
}
