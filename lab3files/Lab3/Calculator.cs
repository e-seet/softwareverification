namespace Lab3
{
    public class Calculator
    {
        public Calculator() { }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return num1 / num2;
        }

        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        public double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Cannot calculate square root of negative number");
            return Math.Sqrt(number);
        }

        public double Factorial(int n)
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
}
