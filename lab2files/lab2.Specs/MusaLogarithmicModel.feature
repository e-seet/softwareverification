Feature: Musa Logarithmic Model Calculator
  In order to perform reliability predictions using the Musa Logarithmic model
  As a system quality engineer
  I want to calculate failure intensity and expected failures using single calculator commands
  So that I can predict system reliability and plan testing strategies

  Background:
    Given I have a calculator

  @FailureIntensity
  Scenario: Calculate current failure intensity using Musa Logarithmic model
    When I have entered 15, 0.2, and 8 into the calculator and press failure intensity
    Then the failure intensity result should be approximately 3.0

  @FailureIntensity
  Scenario: Calculate failure intensity with zero time
    When I have entered 15, 0.2, and 0 into the calculator and press failure intensity
    Then the failure intensity result should be 15

  @FailureIntensity
  Scenario: Calculate failure intensity with high decay parameter
    When I have entered 20, 0.5, and 5 into the calculator and press failure intensity
    Then the failure intensity result should be approximately 1.64

  @FailureIntensity
  Scenario: Calculate failure intensity with low decay parameter
    When I have entered 10, 0.05, and 10 into the calculator and press failure intensity
    Then the failure intensity result should be approximately 6.07

  @ExpectedFailures
  Scenario: Calculate expected failures using Musa Logarithmic model
    When I have entered 15, 0.2, and 8 into the calculator and press expected failures
    Then the expected failures result should be approximately 59.86

  @ExpectedFailures
  Scenario: Calculate expected failures with zero time
    When I have entered 15, 0.2, and 0 into the calculator and press expected failures
    Then the expected failures result should be 0

  @ExpectedFailures
  Scenario: Calculate expected failures with high decay parameter
    When I have entered 20, 0.5, and 5 into the calculator and press expected failures
    Then the expected failures result should be approximately 36.72

  @ExpectedFailures
  Scenario: Calculate expected failures with low decay parameter
    When I have entered 10, 0.05, and 10 into the calculator and press expected failures
    Then the expected failures result should be approximately 78.69
