// 16
namespace Lab1.Tests;

[TestFixture]
public class FactorialTest
{
	private Calculator _calculator;
  	
	[SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Factorial_OfZero_ReturnsOne()
    {
        Assert.That(_calculator.Factorial(0), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_OfOne_ReturnsOne()
    {
        Assert.That(_calculator.Factorial(1), Is.EqualTo(1));
    }

    [Test]
    public void Factorial_OfPositiveInteger_ReturnsCorrectResult()
    {
        Assert.That(_calculator.Factorial(5), Is.EqualTo(120));
    }

    [Test]
    public void Factorial_NegativeInput_ThrowsArgumentException()
    {
        Assert.That(() => _calculator.Factorial(-3), Throws.ArgumentException);
    }

}