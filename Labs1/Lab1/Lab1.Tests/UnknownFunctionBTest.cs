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
// Act
double result = _calculator.UnknownFunctionB(5, 4);
// Assert
Assert.That(result, Is.EqualTo(5));
}
[Test]
public void UnknownFunctionB_WhenGivenTest2_Result()
{
// Act
double result = _calculator.UnknownFunctionB(5, 3);
// Assert
Assert.That(result, Is.EqualTo(10));
}
[Test]
public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
{
// Act
// Assert
Assert.That(() => _calculator.UnknownFunctionB(-4,5), Throws.ArgumentException);
}
[Test]
public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
{
// Act
// Assert
Assert.That(() => _calculator.UnknownFunctionB(4,5), Throws.ArgumentException);
}