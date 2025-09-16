using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorDivisionStepDefinitions
    {
        private double _result;
        private Exception? _exception;
        private readonly ScenarioContext _scenarioContext;

        public UsingCalculatorDivisionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            try
            {
                var calculator = (Calculator)_scenarioContext["Calculator"];
                _result = calculator.Divide(p0, p1);
                _exception = null;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }


        [Then(@"the division result should throw an exception")]
        public void ThenTheDivisionResultShouldThrowAnException()
        {
            Assert.That(_exception, Is.Not.Null);
            Assert.That(_exception, Is.InstanceOf<ArgumentException>());
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositiveInfinity()
        {
            Assert.That(_result, Is.EqualTo(double.PositiveInfinity));
        }
    }
}

