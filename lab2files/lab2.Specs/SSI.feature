Feature: UsingCalculatorSSI
  In order to calculate Shipped Source Instructions
  As a system quality engineer
  I want to be able to calculate the new total number of SSI in successive releases

@SSI
Scenario: Calculate SSI for second release
  Given I have a calculator
  When I have entered 1000, 200, 150, and 50 into the calculator and press SSI
  Then the SSI result should be 1300

@SSI
Scenario: Calculate SSI with no new code
  Given I have a calculator
  When I have entered 1000, 0, 100, and 50 into the calculator and press SSI
  Then the SSI result should be 1050

@SSI
Scenario: Calculate SSI with more deleted than added code
  Given I have a calculator
  When I have entered 1000, 50, 25, and 200 into the calculator and press SSI
  Then the SSI result should be 875


