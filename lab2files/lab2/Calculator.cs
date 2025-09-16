namespace ICT3101_Calculator
{
    public class Calculator
    {
        public Calculator() { }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Divide(double num1, double num2)
        {
            // Handle special cases as per the scenarios
            if (num1 == 0 && num2 == 0)
                return 1; // 0/0 = 1 (as per scenario requirement)
            
            if (num2 == 0)
                return double.PositiveInfinity; // Any number / 0 = positive infinity
            
            return num1 / num2;
        }

        public double Factorial(double n)
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

        public double CalculateMTBF(double totalTime, double numberOfFailures)
        {
            if (numberOfFailures == 0)
                throw new ArgumentException("Number of failures cannot be zero for MTBF calculation");
            return totalTime / numberOfFailures;
        }

        public double CalculateAvailability(double uptime, double totalTime)
        {
            if (totalTime == 0)
                throw new ArgumentException("Total time cannot be zero");
            return uptime / totalTime;
        }

        public double CalculateFailureIntensity(double initialFailureIntensity, double decayParameter, double time)
        {
            return initialFailureIntensity * Math.Exp(-decayParameter * time);
        }

        public double CalculateExpectedFailures(double initialFailureIntensity, double decayParameter, double time)
        {
            return (initialFailureIntensity / decayParameter) * (1 - Math.Exp(-decayParameter * time));
        }

        public double CalculateDefectDensity(double numberOfDefects, double sizeOfSoftware)
        {
            if (sizeOfSoftware == 0)
                throw new ArgumentException("Size of software cannot be zero");
            return numberOfDefects / sizeOfSoftware;
        }

        public double CalculateSSI(double previousSSI, double newCode, double modifiedCode, double deletedCode)
        {
            return previousSSI + newCode + modifiedCode - deletedCode;
        }
    }
}
