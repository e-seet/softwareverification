Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures/intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

@Reliability
Scenario: Calculate current failure intensity
  Given I have a calculator
  When I have entered 10, 0.1, and 5 into the calculator and press failure intensity
  Then the failure intensity result should be approximately 6.07

@Reliability
Scenario: Calculate average number of expected failures
  Given I have a calculator
  When I have entered 10, 0.1, and 5 into the calculator and press expected failures
  Then the expected failures result should be approximately 39.35

@Reliability
Scenario: Calculate failure intensity with zero time
  Given I have a calculator
  When I have entered 10, 0.1, and 0 into the calculator and press failure intensity
  Then the failure intensity result should be 10

@Reliability
Scenario: Calculate expected failures with zero time
  Given I have a calculator
  When I have entered 10, 0.1, and 0 into the calculator and press expected failures
  Then the expected failures result should be 0

