using NUnit.Framework;

[TestFixture]
public class HelloWorldTests
{
    [Test]
    public void TestHelloWorld()
    {
        Assert.That("Hello, World!", Is.EqualTo("Hello, World!"));
    }
}