public class Calculator
{
	public Calculator() { }
	public double DoOperation(double num1, double num2, string op)
	{
		double result = double.NaN; // Default value
									// Use a switch statement to do the math.
		switch (op)
		{
			case "a":
				result = Add(num1, num2);
				break;
			case "s":
				result = Subtract(num1, num2);
				break;
			case "m":
				result = Multiply(num1, num2);
				break;
			case "d":
				// Ask the user to enter a non-zero divisor.
				result = Divide(num1, num2);
				break;
			// Return text for an incorrect option entry.
			default:
				break;
		}
		return result;
	}

	public double Add(double num1, double num2)
	{
		return (num1 + num2);
	}
	public double Subtract(double num1, double num2)
	{ 
		return (num1 - num2); 
	}
	public double Multiply(double num1, double num2)
	{ 
		return (num1 * num2); 
	}

	public double Divide(double num1, double num2)
	{
		return (num1 / num2);
	}
}