using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private Calculator _calculator;
        private double _result;

        //Context Injection for SpecFlow:
        public UsingCalculatorStepDefinitions(Calculator calc)
        {
            this._calculator = calc;
        }
        //--------------------------------

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Calculator is already injected via constructor
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _result = _calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the addition result should be (.*)")]
        public void ThenTheAdditionResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}