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

	[Test]
	public void Add_WhenGivenTwoNumbers_ReturnsSum()
	{
		Assert.That(_calculator.Add(3, 4), Is.EqualTo(7));
		Assert.That(_calculator.Add(-3, 4), Is.EqualTo(1));
		Assert.That(_calculator.Add(0, 0), Is.EqualTo(0));
	}

	[Test]
	public void Subtract_WhenGivenTwoNumbers_ReturnsDifference()
	{
		Assert.That(_calculator.Subtract(10, 5), Is.EqualTo(5));
		Assert.That(_calculator.Subtract(5, 10), Is.EqualTo(-5));
		Assert.That(_calculator.Subtract(0, 0), Is.EqualTo(0));
	}

	[Test]
	public void Multiply_WhenGivenTwoNumbers_ReturnsProduct()
	{
		Assert.That(_calculator.Multiply(3, 4), Is.EqualTo(12));
		Assert.That(_calculator.Multiply(-3, 4), Is.EqualTo(-12));
		Assert.That(_calculator.Multiply(0, 100), Is.EqualTo(0));
	}

	[Test]
	public void Divide_WhenGivenTwoNumbers_ReturnsQuotient()
	{
		Assert.That(_calculator.Divide(10, 2), Is.EqualTo(5));
		Assert.That(_calculator.Divide(9, 3), Is.EqualTo(3));
	}

	[Test]
	public void Divide_ByZero_ReturnsInfinity()
	{
		// double division by zero returns Infinity or -Infinity, not exception
		Assert.That(double.IsInfinity(_calculator.Divide(5, 0)));
	}

	[Test]
	public void Divide_ZeroByNumber_ReturnsZero()
	{
		Assert.That(_calculator.Divide(0, 5), Is.EqualTo(0));
	}

	[Test]
	public void Divide_WithZerosAsInputs_ResultThrowArgumentException()
	{
		Assert.That(() => _calculator.Divide(0, 0), Throws.ArgumentException);
	}


	[Test]
	[TestCase(0, 0)]
	public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
	{
		Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
	}
}