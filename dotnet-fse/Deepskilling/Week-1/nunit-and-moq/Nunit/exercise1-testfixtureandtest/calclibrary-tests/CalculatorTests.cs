using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator = null!;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null!;
        }

        [TestCase(10, 20, 30)]
        [TestCase(15, 25, 40)]
        [TestCase(-5, 5, 0)]
        public void Addition_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Addition(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}