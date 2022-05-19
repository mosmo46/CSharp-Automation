using NUnit.Framework;

namespace TestAutomationCourse.Exercises.e03.Refactoring
{
    [TestFixture]
    internal class CalculatorDisplayTests
    {
        [Test]
        public void test1()
        {
            CalculatorDisplay cd = new CalculatorDisplay();
            string result = cd.GetDisplay();
            Assert.AreEqual("0", result);
        }

        [Test]
        public void test2()
        {
            CalculatorDisplay cd = new CalculatorDisplay();
            cd.Press("1");
            cd.Press("3");
            string result = cd.GetDisplay();
            Assert.AreEqual("13", result);
        }

        [Test]
        public void test3()
        {
            CalculatorDisplay cd = new CalculatorDisplay();
            cd.Press("1");
            cd.Press("+");
            string result = cd.GetDisplay();
            Assert.AreEqual("1", result);
        }

    }
}
