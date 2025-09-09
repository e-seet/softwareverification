namespace Lab1.Tests;

[TestFixture]
public class TDD_AreaTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    // // TDD Part A: Triangle Area Tests (Test Cases First)
    // [Test]
    // public void TriangleArea_ValidInputs_ReturnsCorrectArea()
    // {
    //     // Arrange
    //     double height = 5.0;
    //     double length = 4.0;
    //     double expectedArea = 10.0; // (5 * 4) / 2 = 10

    //     // Act
    //     double result = _calculator.TriangleArea(height, length);

    //     // Assert
    //     Assert.That(result, Is.EqualTo(expectedArea));
    // }

    // [Test]
    // public void TriangleArea_WithDecimals_ReturnsCorrectArea()
    // {
    //     // Arrange
    //     double height = 3.5;
    //     double length = 2.8;
    //     double expectedArea = 4.9; // (3.5 * 2.8) / 2 = 4.9

    //     // Act
    //     double result = _calculator.TriangleArea(height, length);

    //     // Assert
    //     Assert.That(result, Is.EqualTo(expectedArea).Within(0.001));
    // }

    // [Test]
    // public void TriangleArea_ZeroHeight_ThrowsArgumentException()
    // {
    //     // Arrange
    //     double height = 0;
    //     double length = 5.0;

    //     // Act & Assert
    //     Assert.That(() => _calculator.TriangleArea(height, length), Throws.ArgumentException);
    // }

    // [Test]
    // public void TriangleArea_ZeroLength_ThrowsArgumentException()
    // {
    //     // Arrange
    //     double height = 5.0;
    //     double length = 0;

    //     // Act & Assert
    //     Assert.That(() => _calculator.TriangleArea(height, length), Throws.ArgumentException);
    // }

    // [Test]
    // public void TriangleArea_NegativeHeight_ThrowsArgumentException()
    // {
    //     // Arrange
    //     double height = -3.0;
    //     double length = 4.0;

    //     // Act & Assert
    //     Assert.That(() => _calculator.TriangleArea(height, length), Throws.ArgumentException);
    // }

    // [Test]
    // public void TriangleArea_NegativeLength_ThrowsArgumentException()
    // {
    //     // Arrange
    //     double height = 3.0;
    //     double length = -4.0;

    //     // Act & Assert
    //     Assert.That(() => _calculator.TriangleArea(height, length), Throws.ArgumentException);
    // }

    // TDD Part B: Circle Area Tests (Test Cases First)
    [Test]
    public void CircleArea_ValidRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5.0;
        double expectedArea = 78.53981633974483; // π * 5² = 25π ≈ 78.54

        // Act
        double result = _calculator.CircleArea(radius);

        // Assert
        Assert.That(result, Is.EqualTo(expectedArea).Within(0.001));
    }

    [Test]
    public void CircleArea_RadiusOne_ReturnsPi()
    {
        // Arrange
        double radius = 1.0;
        double expectedArea = Math.PI; // π * 1² = π

        // Act
        double result = _calculator.CircleArea(radius);

        // Assert
        Assert.That(result, Is.EqualTo(expectedArea).Within(0.001));
    }

    [Test]
    public void CircleArea_WithDecimals_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 2.5;
        double expectedArea = 19.634954084936208; // π * 2.5² = 6.25π ≈ 19.63

        // Act
        double result = _calculator.CircleArea(radius);

        // Assert
        Assert.That(result, Is.EqualTo(expectedArea).Within(0.001));
    }

    [Test]
    public void CircleArea_ZeroRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = 0;

        // Act & Assert
        Assert.That(() => _calculator.CircleArea(radius), Throws.ArgumentException);
    }

    [Test]
    public void CircleArea_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = -3.0;

        // Act & Assert
        Assert.That(() => _calculator.CircleArea(radius), Throws.ArgumentException);
    }

    [Test]
    public void CircleArea_VerySmallRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 0.1;
        double expectedArea = 0.03141592653589793; // π * 0.1² = 0.01π ≈ 0.0314

        // Act
        double result = _calculator.CircleArea(radius);

        // Assert
        Assert.That(result, Is.EqualTo(expectedArea).Within(0.001));
    }
}
