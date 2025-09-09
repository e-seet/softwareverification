using TechTalk.SpecFlow;
using NUnit.Framework;

[Binding]
public class CalculatorSteps
{
    private int _firstNumber;
    private int _secondNumber;
    private int _result;

    [Given(@"I have entered (.*) into the calculator")]
    public void GivenIHaveEnteredIntoTheCalculator(int number)
    {
        if (_firstNumber == 0) _firstNumber = number;
        else _secondNumber = number;
    }

    [When(@"I press add")]
    public void WhenIPressAdd()
    {
        _result = _firstNumber + _secondNumber;
    }

    [Then(@"the result should be (.*) on the screen")]
    public void ThenTheResultShouldBeOnTheScreen(int expected)
    {
        Assert.AreEqual(expected, _result);
    }
}