using ICT3101_Calculator;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        // Register Calculator instance for dependency injection
        var calculator = new Calculator();
        ScenarioContext.Current["Calculator"] = calculator;
    }
}

