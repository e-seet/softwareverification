Feature: Calculator
  In order to avoid mistakes
  As a math student
  I want to perform mathematical operations correctly

Scenario: Add two numbers
  Given I have entered 50 and 70 into the calculator
  When I press add
  Then the result should be 120 on the screen

Scenario: Subtract two numbers
  Given I have entered 100 and 30 into the calculator
  When I press subtract
  Then the result should be 70 on the screen

Scenario: Multiply two numbers
  Given I have entered 5 and 6 into the calculator
  When I press multiply
  Then the result should be 30 on the screen

Scenario: Divide two numbers
  Given I have entered 15 and 3 into the calculator
  When I press divide
  Then the result should be 5 on the screen

Scenario: Divide by zero should throw exception
  Given I have entered 10 and 0 into the calculator
  When I press divide
  Then an exception should be thrown
  And the exception message should contain "Cannot divide by zero"

Scenario: Calculate factorial
  When I calculate the factorial of 5
  Then the result should be 120

Scenario: Calculate factorial of negative number
  When I calculate the factorial of -1
  Then an exception should be thrown
  And the exception message should contain "Factorial is not defined for negative numbers"

Scenario: Calculate power
  When I calculate 2 to the power of 3
  Then the result should be 8

Scenario: Calculate square root
  When I calculate the square root of 16
  Then the result should be 4

Scenario: Calculate square root of negative number
  When I calculate the square root of -4
  Then an exception should be thrown
  And the exception message should contain "Cannot calculate square root of negative number"