using NUnit.Framework;

namespace TestAutomationCourse.Demos.d01.Nunit
{
    [TestFixture]
    internal class FactorialParameterizedTests
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(-3, 0, Ignore = "Bug")]
        [TestCase(10, 3628800)]
        public void FactorialTests(int input, int expected)
        {
            Factorial factorial = new Factorial();
            Assert.AreEqual(expected, factorial.Calculate(input));

        }

        static object[] FactorialCases()
        {
            return new object[] {
                new object[] { 1,1 }, 
                new object[] {2, 2 }, 
                new object[] {3,6 }, 
                new object[] {10, 3628800 } };
        } 

        [TestCaseSource(nameof(FactorialCases))]
                public void FactorialTests_FromSource(int input, int expected)
        {
            Factorial factorial = new Factorial();
            Assert.AreEqual(expected, factorial.Calculate(input));

        }
    }
}
