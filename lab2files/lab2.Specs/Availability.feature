Feature: UsingCalculatorAvailability
  In order to calculate MTBF and Availability
  As someone who struggles with math
  I want to be able to use my calculator to do this

@Availability
Scenario: Calculating MTBF
  Given I have a calculator
  When I have entered 1000 and 5 into the calculator and press MTBF
  Then the availability result should be 200

@Availability
Scenario: Calculating Availability
  Given I have a calculator
  When I have entered 950 and 1000 into the calculator and press Availability
  Then the availability result should be 0.95

@Availability
Scenario: Calculating MTBF with zero failures should throw exception
  Given I have a calculator
  When I have entered 1000 and 0 into the calculator and press MTBF
  Then the result should throw an exception

@Availability
Scenario: Calculating Availability with zero total time should throw exception
  Given I have a calculator
  When I have entered 950 and 0 into the calculator and press Availability
  Then the result should throw an exception

