using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace TestAutomationCourse.Demos.d06.Web
{
    [TestFixture]
    internal class SelectAndDropDownTests
    {
        IWebDriver driver;
        [Test]
        public void access_the_drop_down()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement country_drop_down = driver.FindElement(By.Name("country"));
            var drop_down_selector = new SelectElement(country_drop_down);
            Assert.That(drop_down_selector.IsMultiple, Is.False);
            Assert.That(drop_down_selector.Options.Count, Is.EqualTo(264));
        }

        [Test]
        public void select_from_the_drop_down_by_text()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement country_drop_down = driver.FindElement(By.Name("country"));
            var drop_down_selector = new SelectElement(country_drop_down);
            drop_down_selector.SelectByText("ISRAEL");
            Assert.That(drop_down_selector.SelectedOption.Enabled, Is.True);
            Assert.That(drop_down_selector.SelectedOption.Displayed, Is.True);
            
            int index = drop_down_selector.Options.IndexOf(drop_down_selector.SelectedOption);
            Assert.That(index, Is.EqualTo(112));
        }

        [Test]
        public void select_from_the_drop_down_by_index()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement country_drop_down = driver.FindElement(By.Name("country"));
            var drop_down_selector = new SelectElement(country_drop_down);
            drop_down_selector.SelectByIndex(112);
            Assert.That(drop_down_selector.SelectedOption.Text, Is.EqualTo("ISRAEL"));
        }

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }

    }
}
