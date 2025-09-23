using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorSSIStepDefinitions
    {
        private double _result;
        private Calculator _calculator;

        //Context Injection for SpecFlow:
        public UsingCalculatorSSIStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }
        //--------------------------------

        [When(@"I have entered (.*), (.*), (.*), and (.*) into the calculator and press SSI")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressSSI(double p0, double p1, double p2, double p3)
        {
            _result = _calculator.CalculateSSI(p0, p1, p2, p3);
        }

        [Then(@"the SSI result should be (.*)")]
        public void ThenTheSSIResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}

