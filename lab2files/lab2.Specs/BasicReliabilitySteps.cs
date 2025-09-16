using ICT3101_Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorBasicReliabilityStepDefinitions
    {
        private double _result;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            // Calculator is registered in Hooks.cs BeforeScenario
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press failure intensity")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressFailureIntensity(double p0, double p1, double p2)
        {
            var calculator = (Calculator)ScenarioContext.Current["Calculator"];
            _result = calculator.CalculateFailureIntensity(p0, p1, p2);
        }

        [When(@"I have entered (.*), (.*), and (.*) into the calculator and press expected failures")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressExpectedFailures(double p0, double p1, double p2)
        {
            var calculator = (Calculator)ScenarioContext.Current["Calculator"];
            _result = calculator.CalculateExpectedFailures(p0, p1, p2);
        }

        [Then(@"the failure intensity result should be approximately (.*)")]
        public void ThenTheFailureIntensityResultShouldBeApproximately(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0).Within(0.1));
        }

        [Then(@"the expected failures result should be approximately (.*)")]
        public void ThenTheExpectedFailuresResultShouldBeApproximately(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0).Within(0.1));
        }

        [Then(@"the failure intensity result should be (.*)")]
        public void ThenTheFailureIntensityResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }

        [Then(@"the expected failures result should be (.*)")]
        public void ThenTheExpectedFailuresResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}

