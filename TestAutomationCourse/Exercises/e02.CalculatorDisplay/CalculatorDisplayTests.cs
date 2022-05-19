using NUnit.Framework;
using TestAutomationCourse.Demos.d01.Nunit;

namespace TestAutomationCourse.Exercises.e02.CalculatorDisplay_1
{
    [TestFixture]
    internal class CalculatorDisplayTests
    {
        [Test]
        public void FirstTest()
        {

            CalculatorDisplay calculatorDisplay = new CalculatorDisplay();
            calculatorDisplay.Press("1");

            Assert.AreEqual("1", calculatorDisplay.getDisplay());
        }
        [Test]
        public void FirstTest1()
        {
            
            CalculatorDisplay calculatorDisplay = new CalculatorDisplay();
            calculatorDisplay.Press("9");
            calculatorDisplay.Press("/");
            calculatorDisplay.Press("3");
            calculatorDisplay.Press("=");
            calculatorDisplay.Press("=");
            calculatorDisplay.Press("=");
            
            Assert.AreEqual("3", calculatorDisplay.getDisplay());
        
        }
        [Test]
        public void FirstTest2()
        {

            CalculatorDisplay calculatorDisplay = new CalculatorDisplay();
            calculatorDisplay.Press("10");
            calculatorDisplay.Press("/");
            calculatorDisplay.Press("5");
            calculatorDisplay.Press("=");
            calculatorDisplay.Press("=");

            Assert.AreEqual("5", calculatorDisplay.getDisplay());

        }
        [Test]
        public void FirstTest3()
        {

            CalculatorDisplay calculatorDisplay = new CalculatorDisplay();
            calculatorDisplay.Press("10");
            calculatorDisplay.Press("+");
            calculatorDisplay.Press("+");
            calculatorDisplay.Press("10");
            calculatorDisplay.Press("=");

            Assert.AreEqual("20", calculatorDisplay.getDisplay());

        }
    }
}
