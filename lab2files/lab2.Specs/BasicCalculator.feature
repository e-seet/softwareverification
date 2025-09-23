Feature: Basic Calculator Operations
  In order to perform fundamental mathematical calculations
  As a calculator user
  I want to be able to perform basic arithmetic operations and mathematical functions
  So that I can solve everyday mathematical problems efficiently

  Background:
    Given I have a calculator

  @BasicMath
  Scenario: Add two positive numbers
    When I have entered 15 and 25 into the calculator and press add
    Then the addition result should be 40

  @BasicMath
  Scenario: Add zero to a number
    When I have entered 10 and 0 into the calculator and press add
    Then the addition result should be 10

  @BasicMath
  Scenario: Add negative numbers
    When I have entered -5 and -3 into the calculator and press add
    Then the addition result should be -8

  @BasicMath
  Scenario: Divide two numbers
    When I have entered 20 and 4 into the calculator and press divide
    Then the division result should be 5

  @BasicMath
  Scenario: Divide by zero should return infinity
    When I have entered 10 and 0 into the calculator and press divide
    Then the division result equals positive_infinity

  @BasicMath
  Scenario: Divide zero by zero should return 1
    When I have entered 0 and 0 into the calculator and press divide
    Then the division result should be 1

  @MathematicalFunctions
  Scenario: Calculate factorial of positive number
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

  @MathematicalFunctions
  Scenario: Calculate factorial of zero
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1

  @MathematicalFunctions
  Scenario: Calculate factorial of one
    When I have entered 1 into the calculator and press factorial
    Then the factorial result should be 1

  @MathematicalFunctions
  Scenario: Calculate factorial of negative number should throw exception
    When I have entered -3 into the calculator and press factorial
    Then the factorial result should throw an exception
