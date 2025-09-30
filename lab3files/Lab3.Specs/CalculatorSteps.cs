using Lab3;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Lab3.Specs
{
    [Binding]
    public sealed class CalculatorSteps
    {
        private Calculator _calculator;
        private double _result;
        private Exception _exception;

        // Context Injection for SpecFlow
        public CalculatorSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(double number)
        {
            // Store the first number for operations
            ScenarioContext.Current["FirstNumber"] = number;
        }

        [Given(@"I have entered (.*) and (.*) into the calculator")]
        public void GivenIHaveEnteredAndIntoTheCalculator(double num1, double num2)
        {
            ScenarioContext.Current["FirstNumber"] = num1;
            ScenarioContext.Current["SecondNumber"] = num2;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var num1 = (double)ScenarioContext.Current["FirstNumber"];
            var num2 = (double)ScenarioContext.Current["SecondNumber"];
            _result = _calculator.Add(num1, num2);
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            var num1 = (double)ScenarioContext.Current["FirstNumber"];
            var num2 = (double)ScenarioContext.Current["SecondNumber"];
            _result = _calculator.Subtract(num1, num2);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            var num1 = (double)ScenarioContext.Current["FirstNumber"];
            var num2 = (double)ScenarioContext.Current["SecondNumber"];
            _result = _calculator.Multiply(num1, num2);
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            try
            {
                var num1 = (double)ScenarioContext.Current["FirstNumber"];
                var num2 = (double)ScenarioContext.Current["SecondNumber"];
                _result = _calculator.Divide(num1, num2);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I calculate the factorial of (.*)")]
        public void WhenICalculateTheFactorialOf(int number)
        {
            try
            {
                _result = _calculator.Factorial(number);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I calculate (.*) to the power of (.*)")]
        public void WhenICalculateToThePowerOf(double baseNumber, double exponent)
        {
            _result = _calculator.Power(baseNumber, exponent);
        }

        [When(@"I calculate the square root of (.*)")]
        public void WhenICalculateTheSquareRootOf(double number)
        {
            try
            {
                _result = _calculator.SquareRoot(number);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.001));
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double expectedResult)
        {
            Assert.That(_result, Is.EqualTo(expectedResult).Within(0.001));
        }

        [Then(@"an exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Assert.That(_exception, Is.Not.Null);
        }

        [Then(@"the exception message should contain ""(.*)""")]
        public void ThenTheExceptionMessageShouldContain(string expectedMessage)
        {
            Assert.That(_exception.Message, Does.Contain(expectedMessage));
        }
    }
}
