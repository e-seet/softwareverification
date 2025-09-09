using NUnit.Framework;  // Required for [Test], Assert.That, Throws

namespace Lab1.Tests
{
	[TestFixture] // optional but recommended
	public class UnknownFunctionBTest
	{
		private Calculator _calculator;

		[SetUp] // runs before each test
		public void Setup()
		{
			_calculator = new Calculator();
		}

		[Test]
		public void UnknownFunctionB_WhenGivenTest0_Result()
		{
			// Act
			double result = _calculator.UnknownFunctionB(5, 5);

			// Assert
			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void UnknownFunctionB_WhenGivenTest1_Result()
		{
			double result = _calculator.UnknownFunctionB(5, 4);
			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		public void UnknownFunctionB_WhenGivenTest2_Result()
		{
			double result = _calculator.UnknownFunctionB(5, 3);
			Assert.That(result, Is.EqualTo(10));
		}

		[Test]
		public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumentException()
		{
			Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
		}

		[Test]
		public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumentException()
		{
			Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
		}
	}
}