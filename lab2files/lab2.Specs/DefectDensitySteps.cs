using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorDefectDensityStepDefinitions
    {
        private double _result;
        private Exception? _exception;


        [When(@"I have entered (.*) and (.*) into the calculator and press defect density")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDefectDensity(double p0, double p1)
        {
            try
            {
                var calculator = (Calculator)ScenarioContext.Current["Calculator"];
                _result = calculator.CalculateDefectDensity(p0, p1);
                _exception = null;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the defect density result should be (.*)")]
        public void ThenTheDefectDensityResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the result should throw an exception")]
        public void ThenTheResultShouldThrowAnException()
        {
            Assert.That(_exception, Is.Not.Null);
            Assert.That(_exception, Is.InstanceOf<ArgumentException>());
        }
    }
}

