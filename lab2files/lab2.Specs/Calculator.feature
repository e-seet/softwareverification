Feature: UsingCalculatorAddition
  In order to avoid mistakes
  As a calculator user
  I want to be told the sum of two numbers

@Addition
Scenario: Add two numbers
  Given I have a calculator
  When I have entered 50 and 70 into the calculator and press add
  Then the result should be 120