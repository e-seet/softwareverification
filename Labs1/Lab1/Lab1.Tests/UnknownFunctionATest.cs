using NUnit.Framework;  // for [Test], Assert.That, Throws

namespace Lab1.Tests
{
	[TestFixture] // optional but recommended for NUnit
	public class UnknownFunctionATest
	{
		private Calculator _calculator;

		[SetUp] // runs before each test
		public void Setup()
		{
			_calculator = new Calculator();
		}

		[Test]
		public void UnknownFunctionA_WhenGivenTest0_Result()
		{
			// Act
			double result = _calculator.UnknownFunctionA(5, 5);

			// Assert
			Assert.That(result, Is.EqualTo(120));
		}

		[Test]
		public void UnknownFunctionA_WhenGivenTest1_Result()
		{
			double result = _calculator.UnknownFunctionA(5, 4);
			Assert.That(result, Is.EqualTo(120));
		}

		[Test]
		public void UnknownFunctionA_WhenGivenTest2_Result()
		{
			double result = _calculator.UnknownFunctionA(5, 3);
			Assert.That(result, Is.EqualTo(60));
		}

		[Test]
		public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumentException()
		{
			Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
		}

		[Test]
		public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumentException()
		{
			Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
		}
	}
}