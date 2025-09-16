Feature: UsingCalculatorFactorial
  In order to calculate factorials
  As a calculator user
  I want to be able to calculate the factorial of a number

@Factorial
Scenario: Calculate factorial of a positive number
  Given I have a calculator
  When I have entered 5 into the calculator and press factorial
  Then the factorial result should be 120

@Factorial
Scenario: Calculate factorial of zero
  Given I have a calculator
  When I have entered 0 into the calculator and press factorial
  Then the factorial result should be 1

@Factorial
Scenario: Calculate factorial of one
  Given I have a calculator
  When I have entered 1 into the calculator and press factorial
  Then the factorial result should be 1

@Factorial
Scenario: Calculate factorial of negative number should throw exception
  Given I have a calculator
  When I have entered -3 into the calculator and press factorial
  Then the factorial result should throw an exception

