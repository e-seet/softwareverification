using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorAvailabilityStepDefinitions
    {
        private double _result;
        private Exception? _exception;


        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double p0, double p1)
        {
            try
            {
                var calculator = (Calculator)ScenarioContext.Current["Calculator"];
                _result = calculator.CalculateMTBF(p0, p1);
                _exception = null;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double p0, double p1)
        {
            try
            {
                var calculator = (Calculator)ScenarioContext.Current["Calculator"];
                _result = calculator.CalculateAvailability(p0, p1);
                _exception = null;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double p0)
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

