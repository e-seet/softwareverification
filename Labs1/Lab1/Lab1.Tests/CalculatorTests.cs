using NUnit.Framework;
using Lab1; // Make sure this matches your main project namespace

namespace Lab1.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            double result = _calculator.Add(10, 20);
            Assert.That(result, Is.EqualTo(30));
        }
    }
}