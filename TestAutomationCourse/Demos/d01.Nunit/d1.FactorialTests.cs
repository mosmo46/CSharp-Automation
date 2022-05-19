using NUnit.Framework;

namespace TestAutomationCourse.Demos.d01.Nunit
{
    [TestFixture]
    public class FactorialTests
    {
        [Test]
        public void Factorial_Tests()
        {
            Factorial factorial = new Factorial();
            Assert.AreEqual(1, factorial.Calculate(1));
            Assert.AreEqual(2, factorial.Calculate(2));
            Assert.AreEqual(6, factorial.Calculate(3));
        }

        [Test]
        [Ignore("bug")]
        public void negative_factorial()
        {
            Factorial factorial = new Factorial();
            Assert.AreEqual(0, factorial.Calculate(-3));
        }

        [Test]
        public void big_factorial()
        {
            Factorial factorial = new Factorial();
            Assert.AreEqual(3628800, factorial.Calculate(10));
        }
    }
}
