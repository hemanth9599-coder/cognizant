using System;
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

        // -----------------------------
        // Exercise 1 - Addition
        // -----------------------------

        [TestCase(10, 20, 30)]
        [TestCase(15, 25, 40)]
        [TestCase(-5, 5, 0)]
        public void Addition_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Addition(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // -----------------------------
        // Exercise 2 - Subtraction
        // -----------------------------

        [TestCase(20, 10, 10)]
        [TestCase(10, 20, -10)]
        [TestCase(-5, -5, 0)]
        public void Subtraction_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Subtraction(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // -----------------------------
        // Exercise 2 - Multiplication
        // -----------------------------

        [TestCase(5, 4, 20)]
        [TestCase(-2, 5, -10)]
        [TestCase(0, 10, 0)]
        public void Multiplication_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Multiplication(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // -----------------------------
        // Exercise 2 - Division
        // -----------------------------

        [TestCase(20, 5, 4)]
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        public void Division_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = calculator.Division(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // -----------------------------
        // Exercise 2 - Division by Zero
        // -----------------------------

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                calculator.Division(10, 0));

            Assert.That(ex!.Message,
                Is.EqualTo("Second Parameter Can't be Zero"));
        }

        // -----------------------------
        // Exercise 2 - AllClear()
        // -----------------------------

        [Test]
        public void AllClear_ShouldResetResultToZero()
        {
            calculator.Addition(10, 20);

            Assert.That(calculator.GetResult, Is.EqualTo(30));

            calculator.AllClear();

            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}