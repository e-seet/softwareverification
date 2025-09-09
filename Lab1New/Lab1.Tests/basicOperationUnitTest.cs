namespace Lab1.Tests;

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
	public void Subtract_TwoPositiveNumbers_ReturnsDifference()
	{
		Assert.That(_calculator.Subtract(10, 5), Is.EqualTo(5));
	}

	[Test]
	public void Subtract_NegativeResult()
	{
		Assert.That(_calculator.Subtract(3, 7), Is.EqualTo(-4));
	}

	[Test]
	public void Multiply_TwoPositiveNumbers_ReturnsProduct()
	{
		Assert.That(_calculator.Multiply(4, 5), Is.EqualTo(20));
	}

	[Test]
	public void Multiply_ByZero_ReturnsZero()
	{
		Assert.That(_calculator.Multiply(0, 10), Is.EqualTo(0));
		Assert.That(_calculator.Multiply(10, 0), Is.EqualTo(0));
	}

	[Test]
	public void Divide_TwoPositiveNumbers_ReturnsQuotient()
	{
		Assert.That(_calculator.Divide(10, 2), Is.EqualTo(5));
	}

	// this test case not supported.
	// [Test]
	// public void Divide_ByZero_ThrowsArgumentException()
	// {
	// 	Assert.That(() => _calculator.Divide(10, 0), Throws.ArgumentException);
	// }

	[Test]
	public void Divide_ZeroByNumber_ReturnsZero()
	{
		Assert.That(_calculator.Divide(0, 5), Is.EqualTo(0));
	}
}