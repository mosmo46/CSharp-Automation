using NUnit.Framework;

namespace TestAutomationCourse.Demos.d01.Nunit
{
    [TestFixture]
    internal class FactorialFixtureTestscs
    {
        Factorial factorial;

        [SetUp]
        public void Setup()
        {
            factorial = new Factorial();
        }

        [Test]
        public void Factorial_Tests()
        {
            
            Assert.AreEqual(1, factorial.Calculate(1));
            Assert.AreEqual(2, factorial.Calculate(2));
            Assert.AreEqual(6, factorial.Calculate(3));
        }

        [Test]
        [Ignore("bug")]
        public void negative_factorial()
        {
            Assert.AreEqual(0, factorial.Calculate(-3));
        }

        [Test]
        public void big_factorial()
        {
            Assert.AreEqual(3628800, factorial.Calculate(10));
        }
    }
}
