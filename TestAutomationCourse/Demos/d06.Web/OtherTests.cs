using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace TestAutomationCourse.Demos.d06.Web
{
    [TestFixture]
    internal class OtherTests
    {
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void text_box_is_enabled()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement name_text = driver.FindElement(By.Name("firstName"));
            Assert.That(name_text.Displayed, Is.True);
            Assert.That(name_text.Enabled, Is.True);
        }

        [Test]
        public void drag_and_drop()
        {
            driver.Url = "http://demo.guru99.com/test/drag_drop.html";
            IWebElement From = driver.FindElement(By.XPath("//*[@id='credit2']/a"));
            var value_dragged = From.Text;
            IWebElement To = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            Assert.That(To.Text, Does.Not.EqualTo(value_dragged));
            Actions action = new Actions(driver);
            action.DragAndDrop(From, To).Build().Perform();
            // need to retake stale element
            To = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            Assert.That(To.Text, Is.EqualTo(value_dragged));


        }

        [Test]
        public void screen_shot()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement name_text = driver.FindElement(By.Name("firstName"));
            name_text.SendKeys("Gil");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@".//Image.png", ScreenshotImageFormat.Png);
        }

        [Test]
        public void upload_files_and_wait_for_message()
        {
            driver.Url = "http://demo.guru99.com/test/upload/";
            IWebElement uploadElement = driver.FindElement(By.Id("uploadfile_0"));

            string path = Path.Combine(Environment.CurrentDirectory, @".//Demos//d06.Web//TextFile1.txt");
            uploadElement.SendKeys(path);
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Name("send")).Click();
            WaitForMessageToDisplay();

            IWebElement message = driver.FindElement(
                By.XPath(".//center[contains(text(), '1 file')]"));

            Assert.That(message.Text, Does.Contain("1 file") 
                & Does.Contain("successfully"));
        }

        private void WaitForMessageToDisplay()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Func<IWebDriver, bool> isMessageDisplayed =
            d =>
            {
                IWebElement e = d.FindElement(By.XPath(".//center[contains(text(), '1 file')]")); ;
                return e.Displayed && e.Enabled;
            };

            wait.Until(isMessageDisplayed);
        }

        [TearDown]
        public void close_browser()
        {
            driver.Close();
            if (File.Exists(@".//Image.png"))
            {
                File.Delete(@".//Image.png");
            }
        }
    }
}
