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

	public double UnknownFunctionA(double n, double r)
	{
		if (n < 0 || r < 0)
			throw new ArgumentException("Parameters cannot be negative");
		if (r > n)
			throw new ArgumentException("r cannot be greater than n");
		
		// This appears to be a permutation calculation: n! / (n-r)!
		double result = 1;
		for (int i = 0; i < r; i++)
		{
			result *= (n - i);
		}
		return result;
	}

	public double UnknownFunctionB(double n, double r)
	{
		if (n < 0 || r < 0)
			throw new ArgumentException("Parameters cannot be negative");
		if (r > n)
			throw new ArgumentException("r cannot be greater than n");
		
		// This appears to be a combination calculation: n! / (r! * (n-r)!)
		// Using the formula: C(n,r) = n! / (r! * (n-r)!)
		double numerator = UnknownFunctionA(n, r); // n! / (n-r)!
		double denominator = Factorial(r); // r!
		return numerator / denominator;
	}

	private double Factorial(double n)
	{
		if (n < 0)
			throw new ArgumentException("Factorial is not defined for negative numbers");
		if (n == 0 || n == 1)
			return 1;
		
		double result = 1;
		for (int i = 2; i <= n; i++)
		{
			result *= i;
		}
		return result;
	}
}