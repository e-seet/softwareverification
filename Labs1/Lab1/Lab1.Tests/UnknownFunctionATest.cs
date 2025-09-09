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
// Act
double result = _calculator.UnknownFunctionA(5, 4);
// Assert
Assert.That(result, Is.EqualTo(120));
}
[Test]
public void UnknownFunctionA_WhenGivenTest2_Result()
{
// Act
double result = _calculator.UnknownFunctionA(5, 3);
// Assert
Assert.That(result, Is.EqualTo(60));
}
[Test]
public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
{
// Act
// Assert
Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
}
[Test]
public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
{
// Act
// Assert
Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
}